#region License
/*
 * Copyright (c) Lightstreamer Srl
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion License

using com.lightstreamer.client;
using System.Diagnostics;
using Xamarin.Forms;

namespace XDemo5
{
    internal class TestConnectionListener : ClientListener
    {
        private RTfeed rTfeed;
        private long bytes;

        public TestConnectionListener(RTfeed rTfeed)
        {
            this.rTfeed = rTfeed;
        }

        // ---

        public void onListenEnd(LightstreamerClient client)
        {
            Debug.WriteLine("Listen End - " + client.Status + " - ");
        }

        public void onListenStart(LightstreamerClient client)
        {
            Debug.WriteLine("Listen Start - " + client.Status + " - ");
        }

        public void onPropertyChange(string property)
        {
            Debug.WriteLine("Property " + property + " changed: ");
            if (rTfeed.ls != null)
            {
                if (property.Equals("serverInstanceAddress"))
                {
                    Debug.WriteLine(rTfeed.ls.connectionDetails.ServerAddress);
                }
                if (property.Equals("sessionId"))
                {
                    Debug.WriteLine(rTfeed.ls.connectionDetails.SessionId);
                }

            }
        }

        public void onServerError(int errorCode, string errorMessage)
        {
            Debug.WriteLine("Server Error - " + errorMessage + " - " + errorCode);
            rTfeed.StatusText = "Server failure: " + errorMessage;
            rTfeed.StatusColor = Color.Red;

            rTfeed.Connect();
        }

        public void onStatusChange(string status)
        {
            Debug.WriteLine(" >>>>>>>>>>>>>>>>>> " + status + " - ");

            if (status.StartsWith("CONNECTED:WS"))
            {
                if (status.EndsWith("POLLING"))
                {
                    Debug.WriteLine("Smart polling session started");
                    rTfeed.StatusText = "Smart polling session started";
                    rTfeed.StatusColor = Color.LightGreen;
                }
                else if (status.EndsWith("STREAMING"))
                {
                    Debug.WriteLine("Streaming session started");
                    rTfeed.StatusText = "Streaming session started";
                    rTfeed.StatusColor = Color.DarkGreen;
                }

                rTfeed.SubscribeAll();
            }
            else if (status.StartsWith("CONNECTED:HT"))
            {
                if (status.EndsWith("POLLING"))
                {
                    Debug.WriteLine("Smart polling session started");
                    rTfeed.StatusText = "Smart polling session started";
                    rTfeed.StatusColor = Color.LightGreen;
                }
                else if (status.EndsWith("STREAMING"))
                {
                    Debug.WriteLine("Streaming session started");
                    rTfeed.StatusText = "Streaming session started";
                    rTfeed.StatusColor = Color.DarkGreen;
                }

                rTfeed.SubscribeAll();
            }
            else if (status.StartsWith("CONNECTING"))
            {
                Debug.WriteLine("Connecting ... ");
                rTfeed.StatusText = "Connecting ... ";
                rTfeed.StatusColor = Color.Orange;
            }
            else if (status.StartsWith("DISCONNECTED"))
            {
                Debug.WriteLine("Connection forcibly closed");
                rTfeed.StatusText = "Connection forcibly closed";
                rTfeed.StatusColor = Color.Red;
            }
            else if (status.StartsWith("STALLED"))
            {
                Debug.WriteLine("Connection no longer stalled");
                rTfeed.StatusText = "Connection no longer stalled";
                rTfeed.StatusColor = Color.YellowGreen;
            }
        }
    }
}
