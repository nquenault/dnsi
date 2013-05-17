using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Alchemy.Classes;

namespace Alchemy.Handlers.WebSocket
{
	internal class WebSocketHandler : Handler
    {
        /// <summary>
        /// Handles the request.
        /// </summary>
        /// <param name="context">The user context.</param>
        public override void HandleRequest(Context context)
        {
            if (context.IsSetup)
            {
                context.UserContext.DataFrame.Append(context.Buffer, true);
                if (context.UserContext.DataFrame.Length <= context.MaxFrameSize)
                {
                    switch (context.UserContext.DataFrame.State)
                    {
                        case DataFrame.DataState.Complete:
                            context.UserContext.OnReceive();
                            break;
                        case DataFrame.DataState.Closed:
                            context.UserContext.Send(context.UserContext.DataFrame.CreateInstance(), false, true);
                            break;
                        case DataFrame.DataState.Ping:
                            context.UserContext.DataFrame.State = DataFrame.DataState.Complete;
                            DataFrame dataFrame = context.UserContext.DataFrame.CreateInstance();
                            dataFrame.State = DataFrame.DataState.Pong;
                            List<ArraySegment<byte>> pingData = context.UserContext.DataFrame.AsRaw();
                            foreach (var item in pingData)
                            {
                                dataFrame.Append(item.Array);
                            }
                            context.UserContext.Send(dataFrame);
                            break;
                        case DataFrame.DataState.Pong:
                            context.UserContext.DataFrame.State = DataFrame.DataState.Complete;
                            break;
                    }
                }
                else
                {
                    context.Disconnect(); //Disconnect if over MaxFrameSize
                }
            }
            else
            {
                Authentication.Authenticate(context);
            }
        }
    }

    /// <summary>
    /// Simple WebSocket data Frame implementation. 
    /// Automatically manages adding received data to an existing frame and checking whether or not we've received the entire frame yet.
    /// See http://www.whatwg.org/specs/web-socket-protocol/ for more details on the WebSocket Protocol.
    /// </summary>
    public abstract class DataFrame
    {
        #region Enumerations

        #region DataFormat enum

        public enum DataFormat
        {
            Unknown = -1,
            Raw = 0,
            Frame = 1
        }

        #endregion

        #region DataState enum

        /// <summary>
        /// The Dataframe's state
        /// </summary>
        public enum DataState
        {
            Empty = -1,
            Receiving = 0,
            Complete = 1,
            Waiting = 2,
            Closed = 3,
            Ping = 4,
            Pong = 5
        }

        #endregion

        #endregion

        public DataFormat Format = DataFormat.Unknown;
        protected DataState InternalState = DataState.Empty;

        /// <summary>
        /// The internal byte buffer used to store data
        /// </summary>
        protected List<ArraySegment<byte>> Payload = new List<ArraySegment<byte>>();

        /// <summary>
        /// Gets the current length of the data
        /// </summary>
        public UInt64 Length
        {
            get
            {
                return Payload.Aggregate<ArraySegment<byte>, ulong>(0,
                                                                    (current, seg) =>
                                                                    current + Convert.ToUInt64(seg.Count));
            }
        }

        /// <summary>
        /// Gets the state.
        /// </summary>
        public DataState State
        {
            get { return InternalState; }
            set { InternalState = value; }
        }

        public abstract DataFrame CreateInstance();

        /// <summary>
        /// Converts the Payload to a websocket Frame
        /// </summary>
        /// <returns></returns>
        public abstract List<ArraySegment<byte>> AsFrame();

        /// <summary>
        /// Converts the Payload to raw data
        /// </summary>
        public abstract List<ArraySegment<byte>> AsRaw();

        /// <summary>
        /// Resets and clears this instance.
        /// </summary>
        public void Reset()
        {
            Payload.Clear();
            Format = DataFormat.Unknown;
            InternalState = DataState.Empty;
        }

        /// <summary>
        /// Appends the data
        /// </summary>
        /// <param name="aString">Some data.</param>
        public void Append(String aString)
        {
            Append(Encoding.UTF8.GetBytes(aString));
        }

        /// <summary>
        /// Appends the data
        /// </summary>
        /// <param name="someBytes">Some data.</param>
        /// /// <param name="asFrame">For internal use inside alchemy.</param>
        public abstract void Append(byte[] someBytes, bool asFrame = false);

        public override string ToString()
        {
            var sb = new StringBuilder();
            List<ArraySegment<byte>> data = AsRaw();
            foreach (var item in data)
            {
                sb.Append(Encoding.UTF8.GetString(item.Array));
            }
            return sb.ToString();
        }
    }
}