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

namespace XDemo5
{
    internal class QuoteListener : SubscriptionListener
    {
        private RTfeed rTfeed;

        public QuoteListener(RTfeed rTfeed)
        {
            this.rTfeed = rTfeed;
        }

        private string NotifyUpdate(ItemUpdate update)
        {
            return update.Snapshot ? "snapshot" : "update";
        }

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
            int itemPos = update.ItemPos;

            Debug.WriteLine("Update received.");

            Debug.WriteLine(NotifyUpdate(update) +
                            " for " + itemPos + ":" + update.getValue(1) + " - " + update.getValue(2)
                           );

            if (itemPos == 1)
            {

                if (update.isValueChanged(2))
                {
                    rTfeed.LabelText0 = update.getValue(2);
                }


                if (update.isValueChanged(1))
                {
                    rTfeed.DescText0 = update.getValue(1);
                }
            }

            if (itemPos == 2)
            {

                if (update.isValueChanged(2))
                {
                    rTfeed.LabelText1 = update.getValue(2);
                }


                if (update.isValueChanged(1))
                {
                    rTfeed.DescText1 = update.getValue(1);
                }
            }

            if (itemPos == 3)
            {

                if (update.isValueChanged(2))
                {
                    rTfeed.LabelText2 = update.getValue(2);
                }


                if (update.isValueChanged(1))
                {
                    rTfeed.DescText2 = update.getValue(1);
                }
            }

            if (itemPos == 4)
            {

                if (update.isValueChanged(2))
                {
                    rTfeed.LabelText3 = update.getValue(2);
                }


                if (update.isValueChanged(1))
                {
                    rTfeed.DescText3 = update.getValue(1);
                }
            }

            if (itemPos == 5)
            {

                if (update.isValueChanged(2))
                {
                    rTfeed.LabelText4 = update.getValue(2);
                }


                if (update.isValueChanged(1))
                {
                    rTfeed.DescText4 = update.getValue(1);
                }
            }

            if (itemPos == 6)
            {

                if (update.isValueChanged(2))
                {
                    rTfeed.LabelText5 = update.getValue(2);
                }


                if (update.isValueChanged(1))
                {
                    rTfeed.DescText5 = update.getValue(1);
                }
            }
        }

        void SubscriptionListener.onListenEnd(Subscription subscription)
        {
            // ...
        }

        void SubscriptionListener.onListenStart(Subscription subscription)
        {
            // ...
        }

        void SubscriptionListener.onSubscription()
        {
            Debug.WriteLine("Subscription");
        }

        void SubscriptionListener.onSubscriptionError(int code, string message)
        {
            Debug.WriteLine("Subscription Error: " + message + " (" + code + ").");
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