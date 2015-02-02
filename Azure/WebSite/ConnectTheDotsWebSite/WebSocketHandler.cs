////  ---------------------------------------------------------------------------------
////  Copyright (c) Microsoft Open Technologies, Inc.  All rights reserved.
//// 
////  The MIT License (MIT)
//// 
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
//// 
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
//// 
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
////  ---------------------------------------------------------------------------------

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web;

//using Microsoft.Web.WebSockets;
//using Microsoft.AspNet.SignalR;

//using Newtonsoft.Json;
//using System.Threading;

//namespace ConnectTheDotsWebSite
//{
//    public class WebSocketConnectController : ApiController
//    {
//        private static Timer _simulationTimer;

//        static WebSocketConnectController()
//        {
//            _simulationTimer = new Timer(state =>
//            {
//                var msg = new Dictionary<string, object>();
//                msg.Add("dspl", "Simuation");
//                msg.Add("temp", 56.3);
//                msg.Add("hmdt", 45);
//                msg.Add("time", ToUnixTime(DateTime.UtcNow));
//                MyWebSocketHandler.SendToClients(msg);
//            }, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
//        }

//        public static long ToUnixTime(DateTime date)
//        {
//            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
//            return Convert.ToInt64((date - epoch).TotalSeconds);
//        }

//        // GET api/<controller>
//        public HttpResponseMessage Get(string clientId)
//        {
//            HttpContext.Current.AcceptWebSocketRequest(new MyWebSocketHandler());
//            return Request.CreateResponse(HttpStatusCode.SwitchingProtocols);
//        }
//    }

//    //class MyWebSocketHandler : WebSocketHandler
//    //{
//    //    private static WebSocketCollection _clients = new WebSocketCollection();

//    //    public string DeviceFilter = null;
//    //    public List<string> DeviceFilterList = new List<string>();
//    //    //public string[] DeviceFilter = new string[1];

//    //    public MyWebSocketHandler()
//    //    {
//    //    }

//    //    public override void OnOpen()
//    //    {
//    //        _clients.Add(this);
//    //        ResendDataToClient();
//    //    }

//        //public void ResendDataToClient()
//        //{
//        //    var bufferedMessages = WebSocketEventProcessor.GetAllBufferedMessages();

//        //    this.Send(JsonConvert.SerializeObject(new Dictionary<string, object> 
//        //        { 
//        //            { "bulkData", true }
//        //        }
//        //    ));


//        //    foreach (var message in bufferedMessages)
//        //    {
//        //        this.SendFiltered(message);
//        //    }

//        //    this.Send(JsonConvert.SerializeObject(new Dictionary<string, object> 
//        //        { 
//        //            { "bulkData", false}
//        //        }
//        //    ));
//        //}

//        //public override void OnClose()
//        //{
//        //    _clients.Remove(this);
//        //    base.OnClose();
//        //}

//        //public override void OnMessage(string message)
//        //{
//        //    try
//        //    {
//        //        var messageDictionary = (IDictionary<string, object>)
//        //            JsonConvert.DeserializeObject(message, typeof(IDictionary<string, object>));

//        //        if (messageDictionary.ContainsKey("MessageType"))
//        //        {
//        //            switch (messageDictionary["MessageType"] as string)
//        //            {
//        //                case "LiveDataSelection":
//        //                    DeviceFilter = messageDictionary["DeviceName"] as string;

//        //                    if (DeviceFilter == "clear")
//        //                    {
//        //                        DeviceFilterList.Clear();
//        //                    }
//        //                    else
//        //                    {
//        //                        DeviceFilterList.Add(DeviceFilter.ToLower());
//        //                    }

//        //                    break;
//        //                default:
//        //                    Trace.TraceError("Client message with unknown message type: {0} - {1}", messageDictionary["MessageType"], message);
//        //                    break;
//        //            }
//        //        }
//        //        else
//        //        {
//        //            Trace.TraceError("Client message without message type: {0}", message);
//        //        }
//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Trace.TraceError("Error processing client message: {0} - {1}", e.Message, message);
//        //    }
//        //    ResendDataToClient();
//        //}

//        public void SendFiltered(IDictionary<string, object> message)
//        {

//            if (!message.ContainsKey("dspl") ||
//                    (this.DeviceFilterList != null && (this.DeviceFilterList.Contains("all")
//                || this.DeviceFilterList.Contains(message["dspl"].ToString().ToLower())

//                )))
//            {

//                this.Send(JsonConvert.SerializeObject(message));
//            }

//            /*
//            if (   !message.ContainsKey("dspl")
//                || (this.DeviceFilter != null 
//                    && (
//                        String.Equals(this.DeviceFilter, "all", StringComparison.InvariantCultureIgnoreCase))
//                        || String.Equals(this.DeviceFilter, message["dspl"])))
//            {
//                this.Send(JsonConvert.SerializeObject(message));
//            }*/
//        }


//    }

//}