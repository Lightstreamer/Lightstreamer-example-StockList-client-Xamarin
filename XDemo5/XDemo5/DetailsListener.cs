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
    internal class DetailsListener : SubscriptionListener
    {
        private RTfeed rTfeed;

        public DetailsListener(RTfeed rTfeed)
        {
            this.rTfeed = rTfeed;
        }

        private string NotifyUpdate(ItemUpdate update)
        {
            return update.Snapshot ? "snapshot" : "update";
        }

        // ---

        void SubscriptionListener.onClearSnapshot(string itemName, int itemPos)
        {
            Debug.WriteLine("Clear snapshot evernt received for " + itemName);
        }

        void SubscriptionListener.onCommandSecondLevelItemLostUpdates(int lostUpdates, string key)
        {
            throw new System.NotImplementedException();
        }

        void SubscriptionListener.onCommandSecondLevelSubscriptionError(int code, string message, string key)
        {
            throw new System.NotImplementedException();
        }

        void SubscriptionListener.onEndOfSnapshot(string itemName, int itemPos)
        {
            Debug.WriteLine("End of snapshot received for " + itemName);
        }

        void SubscriptionListener.onItemLostUpdates(string itemName, int itemPos, int lostUpdates)
        {
            Debug.WriteLine("Lost " + lostUpdates + " updates for " + itemName);
        }

        void SubscriptionListener.onItemUpdate(ItemUpdate update)
        {
            Debug.WriteLine("Details received.");

            Debug.WriteLine(NotifyUpdate(update) +
                            " for " + update.ItemName + ":" + update.getValue(1) + " - " + update.getValue(3)
                           );


            if (update.isValueChanged(1))
            {
                rTfeed.DetailsName = update.getValue(1);
            }

            if (update.isValueChanged(2))
            {
                rTfeed.DetailsLast = update.getValue(2);
            }

            if (update.isValueChanged(3))
            {
                rTfeed.DetailsTime = update.getValue(3);
            }

            if (update.isValueChanged(4))
            {
                rTfeed.DetailsMin = update.getValue(4);
            }

            if (update.isValueChanged(5))
            {
                rTfeed.DetailsMax = update.getValue(5);
            }

            if (update.isValueChanged(6))
            {
                rTfeed.DetailsChg = update.getValue(6);
                if (float.Parse(update.getValue(6)) > 0)
                {
                    rTfeed.DetailsChgDiff = Color.Green;
                }
                else
                {
                    rTfeed.DetailsChgDiff = Color.Red;
                }
            }

            if (update.isValueChanged(7))
            {
                rTfeed.DetailsBid = update.getValue(7);
            }

            if (update.isValueChanged(8))
            {
                rTfeed.DetailsAsk = update.getValue(8);
            }
        }

        void SubscriptionListener.onListenEnd()
        {
            // ...
        }

        void SubscriptionListener.onListenStart()
        {
            // ...
        }

        void SubscriptionListener.onSubscription()
        {
            Debug.WriteLine("Subscription");
        }

        void SubscriptionListener.onSubscriptionError(int code, string message)
        {
            Debug.WriteLine("Subscription Error: " + message + " (" + code +").");
        }

        void SubscriptionListener.onUnsubscription()
        {
            Debug.WriteLine("Unsubscription");
        }

        void SubscriptionListener.onRealMaxFrequency(string frequency)
        {
            Debug.WriteLine("Real Max Frequency: " + frequency);
        }
    }
}
