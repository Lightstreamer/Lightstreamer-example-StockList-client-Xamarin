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
    internal class DetailsListener : IHandyTableListener
    {
        private RTfeed rTfeed;

        public DetailsListener(RTfeed rTfeed)
        {
            this.rTfeed = rTfeed;
        }
        private string NotifyUpdate(IUpdateInfo update)
        {
            return update.Snapshot ? "snapshot" : "update";
        }

        public void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {

            Debug.WriteLine("Details received.");

            Debug.WriteLine(NotifyUpdate(update) +
                            " for " + itemPos + ":" + update.GetNewValue(1) + " - " + update.GetNewValue(3)
                           );
           

            if (update.IsValueChanged(1))
            {
                rTfeed.DetailsName = update.GetNewValue(1);
            }

            if (update.IsValueChanged(2))
            {
                rTfeed.DetailsLast = update.GetNewValue(2);
            }

            if (update.IsValueChanged(3))
            {
                rTfeed.DetailsTime = update.GetNewValue(3);
            }

            if (update.IsValueChanged(4))
            {
                rTfeed.DetailsMin = update.GetNewValue(4);
            }

            if (update.IsValueChanged(5))
            {
                rTfeed.DetailsMax = update.GetNewValue(5);
            }

            if (update.IsValueChanged(6))
            {
                rTfeed.DetailsChg = update.GetNewValue(6);
                if (float.Parse(update.GetNewValue(6)) > 0)
                {
                    rTfeed.DetailsChgDiff = Color.Green;
                } else
                {
                    rTfeed.DetailsChgDiff = Color.Red;
                }
            }

            if (update.IsValueChanged(7))
            {
                rTfeed.DetailsBid = update.GetNewValue(7);
            }

            if (update.IsValueChanged(8))
            {
                rTfeed.DetailsAsk = update.GetNewValue(8);
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
