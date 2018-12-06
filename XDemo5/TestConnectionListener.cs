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

using Lightstreamer.DotNetStandard.Client;
using System.Diagnostics;
using Xamarin.Forms;

namespace XDemo5
{
    internal class TestConnectionListener : IConnectionListener
    {
        private RTfeed rTfeed;
        private long bytes;

        public TestConnectionListener(RTfeed rTfeed)
        {
            this.rTfeed = rTfeed;
        }

        public void OnConnectionEstablished()
        {
            Debug.WriteLine("Connection established");
            rTfeed.StatusText = "Connection established";
            rTfeed.StatusColor = Color.LawnGreen;
        }

        public void OnSessionStarted(bool isPolling)
        {
            if (isPolling)
            {
                Debug.WriteLine("Smart polling session started");
                rTfeed.StatusText = "Smart polling session started";
                rTfeed.StatusColor = Color.LightGreen;
            }
            else
            {
                Debug.WriteLine("Streaming session started");
                rTfeed.StatusText = "Streaming session started";
                rTfeed.StatusColor = Color.DarkGreen;
            }

            rTfeed.SubscribeAll();
        }

        public void OnNewBytes(long newBytes)
        {
            this.bytes += newBytes;
        }

        public void OnDataError(PushServerException e)
        {
            Debug.WriteLine("Data error");
            Debug.WriteLine(e);
        }

        public void OnActivityWarning(bool warningOn)
        {
            if (warningOn)
            {
                Debug.WriteLine("Connection stalled");
                rTfeed.StatusText = "Connection stalled";
                rTfeed.StatusColor = Color.DarkGoldenrod;
            }
            else
            {
                Debug.WriteLine("Connection no longer stalled");
                rTfeed.StatusText = "Connection no longer stalled";
                rTfeed.StatusColor = Color.YellowGreen;
            }
        }

        public void OnClose()
        {
            Debug.WriteLine("total bytes: " + bytes);
        }

        public void OnEnd(int cause)
        {
            Debug.WriteLine("Connection forcibly closed");
            rTfeed.StatusText = "Connection forcibly closed";
            rTfeed.StatusColor = Color.Red;
        }

        public void OnFailure(PushServerException e)
        {
            Debug.WriteLine("Server failure");
            Debug.WriteLine(e);
            rTfeed.StatusText = "Server failure: " + e.Message;
            rTfeed.StatusColor = Color.Red;

            rTfeed.Connect();
        }

        public void OnFailure(PushConnException e)
        {
            Debug.WriteLine("Connection failure");
            Debug.WriteLine(e);
            rTfeed.StatusText = "Server failure: " + e.Message;
            rTfeed.StatusColor = Color.Red;

            rTfeed.Connect();
        }
    }
}
