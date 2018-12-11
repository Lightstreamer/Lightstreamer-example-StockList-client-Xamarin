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

using System;
using System.ComponentModel;
using Xamarin.Forms;

using Lightstreamer.DotNetStandard.Client;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace XDemo5
{
    public class RTfeed : INotifyPropertyChanged
    {

        LSClient ls;
        SubscribedTableKey stk;
        SubscribedTableKey dtk;
        readonly ConnectionInfo connInfo;

        public RTfeed()
        {
            connInfo = new ConnectionInfo
            {
                PushServerUrl = "https://push.lightstreamer.com",
                Adapter = "DEMO",
            };

            Debug.WriteLine("RTFeed Co.");
        }

        public void Disconnect()
        {
            if (ls == null)
            {
                return;
            }

            ls.CloseConnection();

            ls = null;
        }

        public void Connect()
        {
            bool noException = true;

            // Start a new attempt to connect to Lightstreamer server.

            if (ls != null)
            {
                ls.CloseConnection();

                Thread.Sleep(1500);
            }

            while (noException)
            {
                ls = new LSClient();
                try
                {
                    ls.OpenConnection(connInfo, new TestConnectionListener(this));
                    noException = false;
                }
                catch (Lightstreamer.DotNetStandard.Client.PushConnException pce)
                {
                    Debug.WriteLine("Connection failure: " + pce.Message + " - " + pce.StackTrace);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Unexpected event: " + e.StackTrace);
                }
            }
            Debug.WriteLine("Connection ... ");

        }

        public void UnSubscribeDetails()
        {
            if (dtk != null)
            {
                Task taskA = new Task(() =>
                {
                    try
                    {
                        ls.UnsubscribeTable(dtk);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Lightstreamer Unsubscribe error: " + e.Message);
                    }
                });

                // Start the task.
                taskA.Start();
            }
        }

        public void SubscribeDetails(int pos)
        {
            var groupName = "item";
            var schemaName = "stock_name last_price time min max pct_change bid ask";

            groupName += pos;

            if (dtk != null)
            {

                Debug.WriteLine("Here not expected!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                Task taskA = new Task(() =>
                {
                    try
                    {
                        ls.UnsubscribeTable(dtk);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Lightstreamer Unsubscribe error: " + e.Message);
                    }
                });

                // Start the task.
                taskA.Start();

                Thread.Sleep(700);
            }

            Debug.WriteLine("Subscribe Details for " + groupName);

            SimpleTableInfo tableInfo = new SimpleTableInfo(
                       groupName,
                       "MERGE",
                       schemaName,
                       true
                       )
            {
                DataAdapter = "QUOTE_ADAPTER",
                RequestedMaxFrequency = 1.0
            };

            try
            {
                dtk = ls.SubscribeTable(
                    tableInfo,
                    new DetailsListener(this),
                    false
                );
            }
            catch
            {
                Console.WriteLine("Details Error");
            }
        }

        public void SubscribeAll()
        {
            var groupName = "item2 item7 item11 item18 item22 item27";
            // var groupName = "item2";
            var schemaName = "stock_name last_price";

            SimpleTableInfo tableInfo = new SimpleTableInfo(
                       groupName,
                       "MERGE",
                       schemaName,
                       true
                       )
            {
                DataAdapter = "QUOTE_ADAPTER",
                RequestedMaxFrequency = 1.0
            };

            try
            {
                stk = ls.SubscribeTable(
                    tableInfo,
                    new QuoteListener(this),
                    false
                );
            }
            catch
            {
                Console.WriteLine(".");
            }
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string[] rtQuotes = new string[6];
        /*
        public string[] RtQuotes
        {
            get{ (int i) =>
            {
                return rtQuotes[i];
            }
            set(int i)
            {
                rtQuotes[i] = value;
                OnPropertyChanged("LabelText"+i);
            }
        }*/

        private string labelText0;
        public string LabelText0
        {
            get
            {
                return labelText0;
            }
            set
            {
                labelText0 = value;
                OnPropertyChanged("LabelText0");
            }
        }

        private string descText0;
        public string DescText0
        {
            get
            {
                return descText0;
            }
            set
            {
                descText0 = value;
                OnPropertyChanged("DescText0");
            }
        }

        private string labelText1;
        public string LabelText1
        {
            get
            {
                return labelText1;
            }
            set
            {
                labelText1 = value;
                OnPropertyChanged("LabelText1");
            }
        }

        private string descText1;
        public string DescText1
        {
            get
            {
                return descText1;
            }
            set
            {
                descText1 = value;
                OnPropertyChanged("DescText1");
            }
        }

        private string labelText2;
        public string LabelText2
        {
            get
            {
                return labelText2;
            }
            set
            {
                labelText2 = value;
                OnPropertyChanged("LabelText2");
            }
        }

        private string descText2;
        public string DescText2
        {
            get
            {
                return descText2;
            }
            set
            {
                descText2 = value;
                OnPropertyChanged("DescText2");
            }
        }

        private string labelText3;
        public string LabelText3
        {
            get
            {
                return labelText3;
            }
            set
            {
                labelText3 = value;
                OnPropertyChanged("LabelText3");
            }
        }

        private string descText3;
        public string DescText3
        {
            get
            {
                return descText3;
            }
            set
            {
                descText3 = value;
                OnPropertyChanged("DescText3");
            }
        }

        private string labelText4;
        public string LabelText4
        {
            get
            {
                return labelText4;
            }
            set
            {
                labelText4 = value;
                OnPropertyChanged("LabelText4");
            }
        }

        private string descText4;
        public string DescText4
        {
            get
            {
                return descText4;
            }
            set
            {
                descText4 = value;
                OnPropertyChanged("DescText4");
            }
        }

        private string labelText5;
        public string LabelText5
        {
            get
            {
                return labelText5;
            }
            set
            {
                labelText5 = value;
                OnPropertyChanged("LabelText5");
            }
        }

        private string descText5;
        public string DescText5
        {
            get
            {
                return descText5;
            }
            set
            {
                descText5 = value;
                OnPropertyChanged("DescText5");
            }
        }

        private string statusText;
        public string StatusText
        {
            get
            {
                return statusText;
            }
            set
            {
                statusText = value;
                OnPropertyChanged("StatusText");
            }
        }

        private Color statusColor;
        public Color StatusColor
        {
            get
            {
                return statusColor;
            }
            set
            {
                statusColor = value;
                OnPropertyChanged("StatusColor");
            }
        }

        private string detailsName;
        public string DetailsName
        {
            get
            {
                return detailsName;
            }
            set
            {
                detailsName = value;
                OnPropertyChanged("DetailsName");
            }
        }

        private string detailsLast;
        public string DetailsLast
        {
            get
            {
                return detailsLast;
            }
            set
            {
                detailsLast = value;
                OnPropertyChanged("DetailsLast");
            }
        }

        private string detailsTime;
        public string DetailsTime
        {
            get
            {
                return detailsTime;
            }
            set
            {
                detailsTime = value;
                OnPropertyChanged("DetailsTime");
            }
        }

        private string detailsMin;
        public string DetailsMin
        {
            get
            {
                return detailsMin;
            }
            set
            {
                detailsMin = value;
                OnPropertyChanged("DetailsMin");
            }
        }

        private string detailsMax;
        public string DetailsMax
        {
            get
            {
                return detailsMax;
            }
            set
            {
                detailsMax = value;
                OnPropertyChanged("DetailsMax");
            }
        }

        private string detailsChg;
        public string DetailsChg
        {
            get
            {
                return detailsChg;
            }
            set
            {
                detailsChg = value;
                OnPropertyChanged("DetailsChg");
            }
        }

        private Color detailsChgDiff;
        public Color DetailsChgDiff
        {
            get
            {
                return detailsChgDiff;
            }
            set 
            {
                
                detailsChgDiff = value;
                OnPropertyChanged("DetailsChgDiff");
            }
        }

        private string detailsAsk;
        public string DetailsAsk
        {
            get
            {
                return detailsAsk;
            }
            set
            {
                detailsAsk = value;
                OnPropertyChanged("DetailsAsk");
            }
        }

        private string detailsBid;
        public string DetailsBid
        {
            get
            {
                return detailsBid;
            }
            set
            {
                detailsBid = value;
                OnPropertyChanged("DetailsBid");
            }
        }
    }
}