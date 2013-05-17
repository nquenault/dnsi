using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using System.Web;
using Alchemy.Classes;

namespace Alchemy.Handlers.WebSocket.hybi10
{
	internal class FrameHeader
    {
        public const byte EndBit = 0x80;
        public byte CurrentMaskIndex;
        public bool IsEnd = true;
        public bool IsMasked;
        public int Mask;
        public DataFrame.OpCode OpCode = DataFrame.OpCode.Close;

        public UInt64 PayloadSize;
        public UInt64 PayloadSizeRemaining;

        public byte[] FromBytes(byte[] data)
        {
            int dataBegin = 2;
            var nibble2 = (byte) (data[0] & 0x0F);
            var nibble1 = (byte) (data[0] & 0xF0);

            if ((nibble1 & EndBit) == EndBit)
            {
                IsEnd = true;
            }


            //Combine bytes to form one large number
            PayloadSize = (byte) (data[1] & 0x7F);
            if (PayloadSize == 126)
            {
                Array.Reverse(data, dataBegin, 2);
                PayloadSize = BitConverter.ToUInt16(data, dataBegin);
                dataBegin += 2;
            }
            else if (PayloadSize == 127)
            {
                Array.Reverse(data, dataBegin, 8);
                PayloadSize = BitConverter.ToUInt64(data, dataBegin);
                dataBegin += 8;
            }
            PayloadSizeRemaining = PayloadSize;
            IsMasked = Convert.ToBoolean((data[1] & 0x80) >> 7);
            Mask = 0;
            CurrentMaskIndex = 0;
            if (IsMasked)
            {
                Mask = BitConverter.ToInt32(data, dataBegin);
                dataBegin += 4;
            }

            OpCode = (DataFrame.OpCode) nibble2;
            var someBytes = new byte[dataBegin];
            Array.Copy(data, 0, someBytes, 0, dataBegin);
            return someBytes;
        }

        public byte[] ToBytes()
        {
            // wrap the array with the wrapper bytes
            var headerBytes = new List<Byte[]>();
            var data = new byte[1];
            data[0] = 0x81;
            headerBytes.Add(data);
            if (PayloadSize <= 125)
            {
                data = new byte[1];
                data[0] = (byte) PayloadSize;
                //data[0] = (byte) (data[0] | 0x80); //Tells us that this data is masked
                headerBytes.Add(data);
            }
            else
            {
                if (PayloadSize <= ushort.MaxValue)
                {
                    data = new byte[1];
                    data[0] = 126;
                    //data[0] = (byte) (data[0] | 0x80); //Tells us that this data is masked
                    headerBytes.Add(data);

                    data = BitConverter.GetBytes(Convert.ToUInt16(PayloadSize));
                    Array.Reverse(data);
                    headerBytes.Add(data);
                }
                else
                {
                    data = new byte[1];
                    data[0] = 127;
                    //data[0] = (byte) (data[0] | 0x80); //Tells us that this data is masked
                    headerBytes.Add(data);
                    data = BitConverter.GetBytes(PayloadSize);
                    Array.Reverse(data);
                    headerBytes.Add(data);
                }
            }

            //var random = new Random();
            //Mask = random.Next(Int32.MaxValue);
            //headerBytes.Add(BitConverter.GetBytes(Mask));
            return headerBytes.SelectMany(a => a).ToArray();
        }
    }

	/// <summary>
    /// A threadsafe singleton that contains functions which are used to handle incoming connections for the WebSocket Protocol
    /// </summary>
    internal sealed class Handler : WebSocketHandler
    {
        private static Handler _instance;

        private Handler()
        {
            Authentication = new Authentication();
        }

        public new static Handler Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                CreateLock.Wait();
                _instance = new Handler();
                CreateLock.Release();
                return _instance;
            }
        }
    }

    /// <summary>
    /// Handles the handshaking between the client and the host, when a new connection is created
    /// </summary>
    internal class Authentication : Handlers.Authentication
    {
        protected override bool CheckAuthentication(Context context)
        {
            if (context.ReceivedByteCount > 8)
            {
                var handshake = new ClientHandshake(context.Header);
                // See if our header had the required information
                if (handshake.IsValid())
                {
                    // Optionally check Origin and Location if they're set.
                    if (!String.IsNullOrEmpty(Origin))
                    {
                        if (handshake.Origin != "http://" + Origin)
                        {
                            return false;
                        }
                    }
                    if (!String.IsNullOrEmpty(Destination))
                    {
                        if (handshake.Host != Destination + ":" + context.Server.Port.ToString())
                        {
                            return false;
                        }
                    }
                    // Generate response handshake for the client
                    ServerHandshake serverShake = GenerateResponseHandshake(handshake);
                    serverShake.SubProtocol = handshake.SubProtocol;
                    // Send the response handshake
                    SendServerHandshake(serverShake, context);
                    return true;
                }
            }
            return false;
        }

        private static ServerHandshake GenerateResponseHandshake(ClientHandshake handshake)
        {
            var responseHandshake = new ServerHandshake {Accept = GenerateAccept(handshake.Key)};
            return responseHandshake;
        }

        private static void SendServerHandshake(ServerHandshake handshake, Context context)
        {
            // generate a byte array representation of the handshake including the answer to the challenge
            string temp = handshake.ToString();
            byte[] handshakeBytes = Encoding.UTF8.GetBytes(temp);
            context.UserContext.Send(handshakeBytes, true);
        }

        public static string GenerateAccept(string key)
        {
            if (!String.IsNullOrEmpty(key))
            {
                string rawAnswer = key + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";

                // Create a hash of the rawAnswer and return it
                SHA1 hasher = SHA1.Create();
                return Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(rawAnswer)));
            }
            return String.Empty;
        }
    }

	/// <summary>
    /// Simple WebSocket data Frame implementation. 
    /// Automatically manages adding received data to an existing frame and checking whether or not we've received the entire frame yet.
    /// See http://www.whatwg.org/specs/web-socket-protocol/ for more details on the WebSocket Protocol.
    /// </summary>
    public class DataFrame : WebSocket.DataFrame
    {
        #region OpCode enum

        public enum OpCode
        {
            Continue = 0x0,
            Text = 0x1,
            Binary = 0x2,
            Close = 0x8,
            Ping = 0x9,
            Pong = 0xA
        }

        #endregion

        private readonly FrameHeader _header = new FrameHeader();

        public override WebSocket.DataFrame CreateInstance()
        {
            return new DataFrame();
        }

        /// <summary>
        /// Wraps the specified data in WebSocket Start/End Bytes.
        /// Accepts a byte array.
        /// </summary>
        /// <returns>The data array wrapped in WebSocket DataFrame Start/End qualifiers.</returns>
        public override List<ArraySegment<Byte>> AsFrame()
        {
            if (Format == DataFormat.Raw)
            {
                _header.PayloadSize = Length;
                switch (State)
                {
                    case DataState.Pong:
                        _header.OpCode = OpCode.Pong;
                        //Setup Opcode for Pong frame if application has specified that we're sending a pong.
                        break;
                }
                byte[] headerBytes = _header.ToBytes();
                //Mask(); //Uses _header, must call ToBytes before calling Mask
                Payload.Insert(0, new ArraySegment<byte>(headerBytes)); //put header at first position
                Format = DataFormat.Frame;
            }
            return Payload;
        }

        /// <summary>
        /// Returns the data as raw
        /// </summary>
        public override List<ArraySegment<Byte>> AsRaw()
        {
            if (Format == DataFormat.Frame)
            {
                Payload.RemoveAt(0); //Remove header bytes
                Mask(); //unmask data
                Format = DataFormat.Raw;
            }
            return Payload;
        }

        private void Mask()
        {
            foreach (var t in Payload)
            {
                Mask(t.Array);
            }
            _header.CurrentMaskIndex = 0;
        }


        private void Mask(byte[] someBytes)
        {
            byte[] byteKeys = BitConverter.GetBytes(_header.Mask);
            for (int index = 0; index < someBytes.Length; index++)
            {
                someBytes[index] = (byte) (someBytes[index] ^ byteKeys[_header.CurrentMaskIndex]);
                if (_header.CurrentMaskIndex == 3)
                {
                    _header.CurrentMaskIndex = 0;
                }
                else
                {
                    _header.CurrentMaskIndex++;
                }
            }
        }

        public override void Append(byte[] someBytes, bool asFrame = false)
        {
            byte[] data = someBytes;
            if (asFrame)
            {
                UInt64 dataLength;
                if (InternalState == DataState.Empty)
                {
                    byte[] headerBytes = _header.FromBytes(someBytes);
                    Payload.Add(new ArraySegment<byte>(headerBytes));
                    int dataStart = headerBytes.Length;
                    data =
                        new byte[
                            Math.Min(Convert.ToInt32(Math.Min(_header.PayloadSizeRemaining, int.MaxValue)),
                                     someBytes.Length)];
                    dataLength = Math.Min(_header.PayloadSizeRemaining, Convert.ToUInt64(someBytes.Length - dataStart));
                    Array.Copy(someBytes, dataStart, data, 0, Convert.ToInt32(dataLength));
                    Format = DataFormat.Frame;
                }
                else
                {
                    dataLength = Math.Min(Convert.ToUInt64(data.Length), _header.PayloadSizeRemaining);
                    if (dataLength < Convert.ToUInt64(data.Length))
                    {
                        data = new byte[dataLength];
                        Array.Copy(someBytes, 0, data, 0, Convert.ToInt32(dataLength));
                    }
                }

                _header.PayloadSizeRemaining -= dataLength;
                switch (_header.OpCode)
                {
                    case OpCode.Close:
                        InternalState = DataState.Closed;
                        break;
                    case OpCode.Ping:
                        InternalState = DataState.Ping;
                        break;
                    case OpCode.Pong:
                        InternalState = DataState.Pong;
                        break;
                    default:
                        InternalState = _header.PayloadSizeRemaining == 0 ? DataState.Complete : DataState.Receiving;
                        break;
                }
            }
            else
            {
                Format = DataFormat.Raw;
            }
            Payload.Add(new ArraySegment<byte>(data));
        }
    }

    /// <summary>
    /// An easy wrapper for the header to access client handshake data.
    /// See http://www.whatwg.org/specs/web-socket-protocol/ for more details on the WebSocket Protocol.
    /// </summary>
    public class ClientHandshake
    {
        /// <summary>
        /// The preformatted handshake as a string.
        /// </summary>
        private const String Handshake =
            "GET {0} HTTP/1.1\r\n" +
            "Host: {2}\r\n" +
            "Origin: {1}\r\n" +
            "Upgrade: websocket\r\n" +
            "Connection: Upgrade\r\n" +
            "Sec-WebSocket-Key: {4}\r\n" +
            "Sec-WebSocket-Protocol: {3}\r\n" +
            "Sec-WebSocket-Version: 8\r\n" +
            "{5}";

        public string Host = String.Empty;
        public string Key = String.Empty;
        public string Origin = String.Empty;
        public string ResourcePath = String.Empty;

        public ClientHandshake() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientHandshake"/> class.
        /// </summary>
        /// <param name="header">The header.</param>
        public ClientHandshake(Header header)
        {
            ResourcePath = header.RequestPath;
            Key = header["sec-websocket-key"];
            SubProtocol = header["sec-websocket-protocol"];
            Origin = header["origin"];
            if (String.IsNullOrEmpty(Origin))
            {
                Origin = header["sec-websocket-origin"];
            }
            Host = header["host"];
            Version = header["sec-websocket-version"];
            //Cookies = header.Cookies;
        }

        //public HttpCookieCollection Cookies { get; set; }
        public string SubProtocol { get; set; }
        public string Version { get; set; }
        public Dictionary<string, string> AdditionalFields { get; set; }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid()
        {
            return (
                       (Host != null) &&
                       (Key != null) &&
                       (Int32.Parse(Version) >= 8)
                   );
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string additionalFields = String.Empty;

            /*if (Cookies != null)
            {
                additionalFields += "Cookie: " + Cookies + "\r\n";
            }*/

            if (additionalFields != String.Empty)
            {
                additionalFields = AdditionalFields.Aggregate(additionalFields,
                                                              (current, field) =>
                                                              current + (field.Key + ": " + field.Value + "\r\n"));
            }
            additionalFields += "\r\n";

            return String.Format(Handshake, ResourcePath, Origin, Host, SubProtocol, Key, additionalFields);
        }
    }

    /// <summary>
    /// Implements a server handshake
    /// See http://www.whatwg.org/specs/web-socket-protocol/ for more details on the WebSocket Protocol.
    /// </summary>
    public class ServerHandshake
    {
        /// <summary>
        /// The preformatted handshake string.
        /// </summary>
        private const string Handshake =
            "HTTP/1.1 101 Switching Protocols\r\n" +
            "Upgrade: websocket\r\n" +
            "Connection: Upgrade\r\n" +
            "Sec-WebSocket-Accept: {0}\r\n" +
            "{1}";

        public ServerHandshake() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerHandshake"/> class.
        /// </summary>
        /// <param name="header">The header.</param>
        public ServerHandshake(Header header)
        {
            Accept = header["Sec-WebSocket-Accept"];
            SubProtocol = header["Sec-WebSocket-Protocol"];
        }

        public string Accept { get; set; }
        public string SubProtocol { get; set; }

        public Dictionary<string, string> AdditionalFields { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string additionalFields = String.Empty;
            if (SubProtocol != null)
            {
                additionalFields += "Sec-WebSocket-Protocol: " + SubProtocol + "\r\n";
            }
            additionalFields += "\r\n";
            return String.Format(Handshake, Accept, additionalFields);
        }
    }
}