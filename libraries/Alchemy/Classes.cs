using System;
using System.Net;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
//using System.Web;
using System.Net.Sockets;
using System.Threading;
using Alchemy.Handlers.WebSocket;
using Alchemy.Handlers;


namespace Alchemy.Classes
{
	/// <summary>
    /// This class contains the required data for each connection to the server.
    /// </summary>
    public class Context : IDisposable
    {
        /// <summary>
        /// The exported version of this context.
        /// </summary>
        public readonly UserContext UserContext;

        /// <summary>
        /// The buffer used for accepting raw data from the socket.
        /// </summary>
        public byte[] Buffer;

        /// <summary>
        /// Whether or not the TCPClient is still connected.
        /// </summary>
        public bool Connected = true;

        /// <summary>
        /// The raw client connection.
        /// </summary>
        public TcpClient Connection;

        /// <summary>
        /// The current connection handler.
        /// </summary>
        public Handler Handler = Handler.Instance;

        /// <summary>
        /// The Header
        /// </summary>
        public Header Header;

        /// <summary>
        /// Whether or not this client has passed all the setup routines for the current handler(authentication, etc)
        /// </summary>
        public Boolean IsSetup;

        /// <summary>
        /// The max frame that we will accept from the client
        /// </summary>
        public UInt64 MaxFrameSize = 102400; //100kb

        /// <summary>
        /// Semaphores that limit sends and receives to 1 and a time.
        /// </summary>
        public SemaphoreSlim ReceiveReady = new SemaphoreSlim(1);

        /// <summary>
        /// How many bytes we received this tick.
        /// </summary>
        public int ReceivedByteCount;

        public SemaphoreSlim SendReady = new SemaphoreSlim(1);

        /// <summary>
        /// A link to the server listener instance this client is currently hosted on.
        /// </summary>
        public WebSocketServer Server;

        private int _bufferSize = 512;

        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        public Context(WebSocketServer server, TcpClient connection)
        {
            Server = server;
            Connection = connection;
            Buffer = new byte[_bufferSize];
            UserContext = new UserContext(this) {ClientAddress = connection.Client.RemoteEndPoint};
        }

        /// <summary>
        /// Gets or sets the size of the buffer.
        /// </summary>
        /// <value>
        /// The size of the buffer.
        /// </value>
        public int BufferSize
        {
            get { return _bufferSize; }
            set
            {
                _bufferSize = value;
                Buffer = new byte[_bufferSize];
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Connected = false;
            UserContext.OnDisconnect();
        }

        #endregion

        /// <summary>
        /// Disconnects the client
        /// </summary>
        public void Disconnect()
        {
            Connected = false;
        }

        /// <summary>
        /// Resets this instance.
        /// Clears the dataframe if necessary. Resets Received byte count.
        /// </summary>
        public void Reset()
        {
            if (UserContext.DataFrame != null)
            {
                if (UserContext.DataFrame.State == DataFrame.DataState.Complete)
                {
                    UserContext.DataFrame.Reset();
                }
            }
            ReceivedByteCount = 0;
        }
    }

    /// <summary>
    /// What protocols we support
    /// </summary>
    public enum Protocol
    {
        None = -1,
        WebSocketHybi10 = 0,
        WebSocketHybi00 = 1
    }

    /// <summary>
    /// This class implements a rudimentary HTTP header reading interface.
    /// </summary>
    public class Header
    {
        /// <summary>
        /// Regular expression to parse http header
        /// </summary>
        public static string Pattern =
            @"^(?<connect>[^\s]+)?\s?(?<path>[^\s]+)?\s?HTTP\/1\.1(.*?)?\r\n" + // HTTP Request
            @"((?<field_name>[^:\r\n]+):(?<field_value>[^\r\n]+)\r\n)+";

        // HTTP Header Fields (<Field_Name>: <Field_Value> CR LF)

        /// <summary>
        /// A collection of fields attached to the header.
        /// </summary>
        private readonly NameValueCollection _fields = new NameValueCollection();

        /// <summary>
        /// Any cookies sent with the header.
        /// </summary>
        //public HttpCookieCollection Cookies = new HttpCookieCollection();

        /// <summary>
        /// The HTTP Method (GET/POST/PUT, etc.)
        /// </summary>
        public String Method = String.Empty;

        /// <summary>
        /// What protocol this header represents, if any.
        /// </summary>
        public Protocol Protocol = Protocol.None;


        /// <summary>
        /// The path requested by the header.
        /// </summary>
        public string RequestPath = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Header"/> class.
        /// Accepts a string that represents an HTTP header.
        /// </summary>
        /// <param name="data">The data.</param>
        public Header(string data)
        {
            // Parse HTTP Header
            var regex = new Regex(Pattern, RegexOptions.IgnoreCase);
            Match match = regex.Match(data);
            GroupCollection someFields = match.Groups;
            Group fieldNameCollection = someFields["field_name"];
            Group fieldValueCollection = someFields["field_value"];
            if (fieldNameCollection != null && fieldValueCollection != null)
            {
                // run through every match and save them in the handshake object
                for (int i = 0; i < fieldNameCollection.Captures.Count; i++)
                {
                    string name = fieldNameCollection.Captures[i].ToString().ToLower();
                    string value = fieldValueCollection.Captures[i].ToString().Trim();
                    switch (name)
                    {
                        case "cookie":
                            string[] cookieArray = value.Split(';');
                            foreach (string cookie in cookieArray)
                            {
                                int cookieIndex = cookie.IndexOf('=');
                                if (cookieIndex >= 0)
                                {
                                    string cookieName = cookie.Remove(cookieIndex).TrimStart();
                                    string cookieValue = cookie.Substring(cookieIndex + 1);
                                    if (cookieName != string.Empty)
                                    {
                                       // Cookies.Add(new HttpCookie(cookieName, cookieValue));
                                    }
                                }
                            }
                            break;
                        default:
                            _fields.Add(name, value);
                            break;
                    }
                }
            }

            Group pathCollection = someFields["path"];
            Group methodCollection = someFields["connect"];

            if (pathCollection != null)
            {
                if (pathCollection.Captures.Count > 0)
                {
                    RequestPath = pathCollection.Captures[0].Value.Trim();
                }
            }
            if (methodCollection != null)
            {
                if (methodCollection.Captures.Count > 0)
                {
                    Method = methodCollection.Captures[0].Value.Trim();
                }
            }

            int version;
            Int32.TryParse(_fields["sec-websocket-version"], out version);

            Protocol = version < 8 ? Protocol.WebSocketHybi00 : Protocol.WebSocketHybi10;
        }

        /// <summary>
        /// Gets or sets the Fields object with the specified key.
        /// </summary>
        public string this[string key]
        {
            get { return _fields[key]; }
            set { _fields[key] = value; }
        }
    }

	/// <summary>
    /// Container class for Responses.
    /// </summary>
    public abstract class Response
    {
        public const string NotImplemented = "HTTP/1.1 501 Not Implemented";
    }

    /// <summary>
    /// Contains data we will export to the Event Delegates.
    /// </summary>
    public class UserContext
    {
        /// <summary>
        /// AQ Link to the parent User Context
        /// </summary>
        private readonly Context _context;

        /// <summary>
        /// The remote endpoint address.
        /// </summary>
        public EndPoint ClientAddress;

        /// <summary>
        /// User defined data. Can be anything.
        /// </summary>
        public Object Data;

        /// <summary>
        /// The data Frame that this client is currently processing.
        /// </summary>
        public DataFrame DataFrame;

        /// <summary>
        /// OnEvent Delegates specific to this connection.
        /// </summary>
        protected OnEventDelegate OnConnectDelegate = x => { };

        protected OnEventDelegate OnConnectedDelegate = x => { };
        protected OnEventDelegate OnDisconnectDelegate = x => { };
        protected OnEventDelegate OnReceiveDelegate = x => { };
        protected OnEventDelegate OnSendDelegate = x => { };

        /// <summary>
        /// The type of connection this is
        /// </summary>
        public Protocol Protocol = Protocol.None;

        /// <summary>
        /// The path of this request.
        /// </summary>
        public string RequestPath = "/";

        /// <summary>
        /// Initializes a new instance of the <see cref="UserContext"/> class.
        /// </summary>
        /// <param name="context">The user context.</param>
        public UserContext(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// The internal context connection header
        /// </summary>
        public Header Header
        {
            get { return _context.Header; }
        }

        /// <summary>
        /// The maximum frame size
        /// </summary>
        public UInt64 MaxFrameSize
        {
            get { return _context.MaxFrameSize; }
            set { _context.MaxFrameSize = value; }
        }

        /// <summary>
        /// Called when [connect].
        /// </summary>
        public void OnConnect()
        {
            OnConnectDelegate(this);
        }

        /// <summary>
        /// Called when [connected].
        /// </summary>
        public void OnConnected()
        {
            OnConnectedDelegate(this);
        }

        /// <summary>
        /// Called when [disconnect].
        /// </summary>
        public void OnDisconnect()
        {
            _context.Connected = false;
            OnDisconnectDelegate(this);
        }

        /// <summary>
        /// Called when [send].
        /// </summary>
        public void OnSend()
        {
            OnSendDelegate(this);
        }

        /// <summary>
        /// Called when [receive].
        /// </summary>
        public void OnReceive()
        {
            OnReceiveDelegate(this);
        }

        /// <summary>
        /// Sets the on connect event.
        /// </summary>
        /// <param name="aDelegate">The Event Delegate.</param>
        public void SetOnConnect(OnEventDelegate aDelegate)
        {
            OnConnectDelegate = aDelegate;
        }

        /// <summary>
        /// Sets the on connected event.
        /// </summary>
        /// <param name="aDelegate">The Event Delegate.</param>
        public void SetOnConnected(OnEventDelegate aDelegate)
        {
            OnConnectedDelegate = aDelegate;
        }

        /// <summary>
        /// Sets the on disconnect event.
        /// </summary>
        /// <param name="aDelegate">The Event Delegate.</param>
        public void SetOnDisconnect(OnEventDelegate aDelegate)
        {
            OnDisconnectDelegate = aDelegate;
        }

        /// <summary>
        /// Sets the on send event.
        /// </summary>
        /// <param name="aDelegate">The Event Delegate.</param>
        public void SetOnSend(OnEventDelegate aDelegate)
        {
            OnSendDelegate = aDelegate;
        }

        /// <summary>
        /// Sets the on receive event.
        /// </summary>
        /// <param name="aDelegate">The Event Delegate.</param>
        public void SetOnReceive(OnEventDelegate aDelegate)
        {
            OnReceiveDelegate = aDelegate;
        }

        /// <summary>
        /// Sends the specified data.
        /// </summary>
        /// <param name="dataFrame">The data.</param>
        /// <param name="raw">Whether or not to send raw data</param>
        /// <param name="close">if set to <c>true</c> [close].</param>
        public void Send(DataFrame dataFrame, bool raw = false, bool close = false)
        {
            _context.Handler.Send(dataFrame, _context, raw, close);
        }

        /// <summary>
        /// Sends the specified data.
        /// </summary>
        /// <param name="aString">The data.</param>
        /// <param name="raw">whether or not to send raw data</param>
        /// <param name="close">if set to <c>true</c> [close].</param>
        public void Send(String aString, bool raw = false, bool close = false)
        {
            DataFrame dataFrame = DataFrame.CreateInstance();
            dataFrame.Append(aString);
            _context.Handler.Send(dataFrame, _context, raw, close);
        }

        /// <summary>
        /// Sends the specified data.
        /// </summary>
        /// <param name="someBytes">The data.</param>
        /// <param name="raw">whether or not to send raw data</param>
        /// <param name="close">if set to <c>true</c> [close].</param>
        public void Send(byte[] someBytes, bool raw = false, bool close = false)
        {
            DataFrame dataFrame = DataFrame.CreateInstance();
            dataFrame.Append(someBytes);
            _context.Handler.Send(dataFrame, _context, raw, close);
        }
    }
}