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

namespace XDemo5
{
    internal class QuoteListener : IHandyTableListener
    {
        private RTfeed rTfeed;

        public QuoteListener(RTfeed rTfeed)
        {
            this.rTfeed = rTfeed;
        }

        private string NotifyUpdate(IUpdateInfo update)
        {
            return update.Snapshot ? "snapshot" : "update";
        }

        public void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {

            Debug.WriteLine("Update received.");

            Debug.WriteLine(NotifyUpdate(update) +
                            " for " + itemPos + ":" + update.GetNewValue(1) + " - " + update.GetNewValue(2)
                           );

            if (itemPos == 1)
            {

                if (update.IsValueChanged(2))
                {
                    rTfeed.LabelText0 = update.GetNewValue(2);
                }


                if (update.IsValueChanged(1))
                {
                    rTfeed.DescText0 = update.GetNewValue(1);
                }
            }
            
            if (itemPos == 2)
            {

                if (update.IsValueChanged(2))
                {
                    rTfeed.LabelText1 = update.GetNewValue(2);
                }


                if (update.IsValueChanged(1))
                {
                    rTfeed.DescText1 = update.GetNewValue(1);
                }
            }

            if (itemPos == 3)
            {

                if (update.IsValueChanged(2))
                {
                    rTfeed.LabelText2 = update.GetNewValue(2);
                }


                if (update.IsValueChanged(1))
                {
                    rTfeed.DescText2 = update.GetNewValue(1);
                }
            }

            if (itemPos == 4)
            {

                if (update.IsValueChanged(2))
                {
                    rTfeed.LabelText3 = update.GetNewValue(2);
                }


                if (update.IsValueChanged(1))
                {
                    rTfeed.DescText3 = update.GetNewValue(1);
                }
            }

            if (itemPos == 5)
            {

                if (update.IsValueChanged(2))
                {
                    rTfeed.LabelText4 = update.GetNewValue(2);
                }


                if (update.IsValueChanged(1))
                {
                    rTfeed.DescText4 = update.GetNewValue(1);
                }
            }

            if (itemPos == 6)
            {

                if (update.IsValueChanged(2))
                {
                    rTfeed.LabelText5 = update.GetNewValue(2);
                }


                if (update.IsValueChanged(1))
                {
                    rTfeed.DescText5 = update.GetNewValue(1);
                }
            }
        }

        public void OnSnapshotEnd(int itemPos, string itemName)
        {
            Debug.WriteLine("end of snapshot for " + itemPos);
        }

        public void OnRawUpdatesLost(int itemPos, string itemName, int lostUpdates)
        {
            Debug.WriteLine(lostUpdates + " updates lost for " + itemPos);
        }

        public void OnUnsubscr(int itemPos, string itemName)
        {
            Debug.WriteLine("unsubscr " + itemPos);
        }

        public void OnUnsubscrAll()
        {
            Debug.WriteLine("unsubscr table");
        }
    }
}