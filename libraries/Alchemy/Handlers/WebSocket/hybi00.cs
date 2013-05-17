using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using System.Web;
using Alchemy.Classes;

namespace Alchemy.Handlers.WebSocket.hybi00
{
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
            "Upgrade: WebSocket\r\n" +
            "Connection: Upgrade\r\n" +
            "Origin: {1}\r\n" +
            "Host: {2}\r\n" +
            "Sec-Websocket-Key1: {3}\r\n" +
            "Sec-Websocket-Key2: {4}\r\n" +
            "{5}";

        public string Host = String.Empty;
        public string Key1 = String.Empty;
        public string Key2 = String.Empty;
        public string Origin = String.Empty;
        public string ResourcePath = String.Empty;

        public ClientHandshake() {}

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientHandshake"/> class.
        /// </summary>
        /// <param name="challengeBytes">The challenge bytes.</param>
        /// <param name="header">The header.</param>
        public ClientHandshake(ArraySegment<byte> challengeBytes, Header header)
        {
            ChallengeBytes = challengeBytes;
            ResourcePath = header.RequestPath;
            Key1 = header["sec-websocket-key1"];
            Key2 = header["sec-websocket-key2"];
            SubProtocol = header["sec-websocket-protocol"];
            Origin = header["origin"];
            Host = header["host"];
            //Cookies = header.Cookies;
        }

        public ArraySegment<byte> ChallengeBytes { get; set; }
        //public HttpCookieCollection Cookies { get; set; }
        public string SubProtocol { get; set; }
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
                       (Key1 != null) &&
                       (Key2 != null) &&
                       (Origin != null) &&
                       (ResourcePath != null)
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
            if (SubProtocol != null)
            {
                additionalFields += "Sec-Websocket-Protocol: " + SubProtocol + "\r\n";
            }

            if (additionalFields != String.Empty)
            {
                additionalFields = AdditionalFields.Aggregate(additionalFields,
                                                              (current, field) =>
                                                              current + (field.Key + ": " + field.Value + "\r\n"));
            }
            additionalFields += "\r\n";

            return String.Format(Handshake, ResourcePath, Origin, Host, Key1, Key2, additionalFields);
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
            "HTTP/1.1 101 Web Socket Protocol Handshake\r\n" +
            "Upgrade: WebSocket\r\n" +
            "Connection: Upgrade\r\n" +
            "Sec-WebSocket-Origin: {0}\r\n" +
            "Sec-WebSocket-Location: {1}\r\n" +
            "{2}" +
            "                "; //Empty space for challenge answer

        public string Location = String.Empty;
        public string Origin = String.Empty;
        public byte[] AnswerBytes { get; set; }
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

            return String.Format(Handshake, Origin, Location, additionalFields);
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
    /// Simple WebSocket data Frame implementation. 
    /// Automatically manages adding received data to an existing frame and checking whether or not we've received the entire frame yet.
    /// See http://www.whatwg.org/specs/web-socket-protocol/ for more details on the WebSocket Protocol.
    /// </summary>
    public class DataFrame : WebSocket.DataFrame
    {
        public const byte StartByte = 0;
        public const byte EndByte = 255;

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
                // wrap the array with the wrapper bytes
                var startBytes = new byte[1];
                startBytes[0] = StartByte;
                var endBytes = new byte[1];
                endBytes[0] = EndByte;
                Payload.Insert(0, new ArraySegment<byte>(startBytes)); //Add header byte
                Payload.Add(new ArraySegment<byte>(endBytes)); //put termination byte at end
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
                Payload.RemoveAt(0); //remove header byte
                Payload.RemoveAt(Payload.Count - 1); //remove termination byte
                Format = DataFormat.Raw;
            }
            return Payload;
        }

        /// <summary>
        /// Appends the specified data to the internal byte buffer.
        /// </summary>
        /// <param name="data">The data.</param>
        /// /// <param name="asFrame">For internal Alchemy use.</param>
        public override void Append(byte[] data, bool asFrame = false)
        {
            if (asFrame)
            {
                Format = DataFormat.Frame;
                if (data.Length > 0)
                {
                    int end = Array.IndexOf(data, EndByte);
                    if (end != -1)
                    {
                        InternalState = DataState.Complete;
                    }
                    else //If no match found, default.
                    {
                        end = data.Length;
                        InternalState = DataState.Receiving;
                    }

                    int start = Array.IndexOf(data, StartByte);
                    if ((start != -1) && (start < end))
                        // Make sure the start is before the end and that we actually found a match.
                    {
                        var startBytes = new byte[1];
                        startBytes[0] = StartByte;
                        Payload.Add(new ArraySegment<byte>(startBytes));
                        start++; // Do not include the Start Byte
                    }
                    else //If no match found, default.
                    {
                        start = 0;
                    }

                    var temp = new byte[end - start];
                    Array.Copy(data, start, temp, 0, end - start);
                    Payload.Add(new ArraySegment<byte>(temp));
                    if (State == DataState.Complete)
                    {
                        var endBytes = new byte[1];
                        endBytes[0] = EndByte;
                        Payload.Add(new ArraySegment<byte>(endBytes));
                    }
                }
            }
            else
            {
                Format = DataFormat.Raw;
                var temp = new byte[data.Length];
                Array.Copy(data, 0, temp, 0, data.Length);
                Payload.Add(new ArraySegment<byte>(temp));
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
                var handshake =
                    new ClientHandshake(new ArraySegment<byte>(context.Buffer, context.ReceivedByteCount - 8, 8),
                                        context.Header);
                // See if our header had the required information
                if (handshake.IsValid())
                {
                    // Optionally check Origin and Location if they're set.
                    if (Origin != string.Empty)
                    {
                        if (handshake.Origin != "http://" + Origin)
                        {
                            return false;
                        }
                    }
                    if (Destination != string.Empty)
                    {
                        if (handshake.Host != Destination + ":" + context.Server.Port.ToString())
                        {
                            return false;
                        }
                    }
                    // Generate response handshake for the client
                    ServerHandshake serverShake = GenerateResponseHandshake(handshake);
                    // Send the response handshake
                    SendServerHandshake(serverShake, context);
                    return true;
                }
            }
            return false;
        }

        private static ServerHandshake GenerateResponseHandshake(ClientHandshake handshake)
        {
            var responseHandshake = new ServerHandshake
            {
                Location = "ws://" + handshake.Host + handshake.ResourcePath,
                Origin = handshake.Origin,
                SubProtocol = handshake.SubProtocol,
                AnswerBytes = GenerateAnswerBytes(handshake.Key1, handshake.Key2, handshake.ChallengeBytes)
            };

            return responseHandshake;
        }

        private static void SendServerHandshake(ServerHandshake handshake, Context context)
        {
            // generate a byte array representation of the handshake including the answer to the challenge
            byte[] handshakeBytes = Encoding.UTF8.GetBytes(handshake.ToString());
            Array.Copy(handshake.AnswerBytes, 0, handshakeBytes, handshakeBytes.Length - 16, 16);

            context.UserContext.Send(handshakeBytes, true);
        }

        private static byte[] TranslateKey(string key)
        {
            //  Count total spaces in the keys
            int keySpaceCount = key.Count(x => x == ' ');

            // Get a number which is a concatenation of all digits in the keys.
            var keyNumberString = new String(key.Where(Char.IsDigit).ToArray());

            // Divide the number with the number of spaces
            var keyResult = (Int32) (Int64.Parse(keyNumberString)/keySpaceCount);

            // convert the results to 32 bit big endian byte arrays
            byte[] keyResultBytes = BitConverter.GetBytes(keyResult);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(keyResultBytes);
            }
            return keyResultBytes;
        }

        private static byte[] GenerateAnswerBytes(string key1, string key2, ArraySegment<byte> challenge)
        {
            // Translate the two keys, concatenate them and the 8 challenge bytes from the client
            var rawAnswer = new byte[16];
            Array.Copy(TranslateKey(key1), 0, rawAnswer, 0, 4);
            Array.Copy(TranslateKey(key2), 0, rawAnswer, 4, 4);
            Array.Copy(challenge.Array, challenge.Offset, rawAnswer, 8, 8);

            // Create a hash of the rawAnswer and return it
            MD5 hasher = MD5.Create();
            return hasher.ComputeHash(rawAnswer);
        }
    }
}