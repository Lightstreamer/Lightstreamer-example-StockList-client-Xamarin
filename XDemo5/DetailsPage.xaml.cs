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
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XDemo5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailsPage : ContentPage
	{

        TextCell[] txtDtls;
        TableView myTable;
        StackLayout detailsLayout;
        RTfeed __myClass;

        public DetailsPage(RTfeed _myClass, int pos)
		{
			InitializeComponent ();

            __myClass = _myClass;

            Disappearing += EventPage_OnDisappearing;

            __myClass.SubscribeDetails(pos);

            BindingContext = _myClass;

            txtDtls = new TextCell[8];

            txtDtls[0] = new TextCell { Text = "0.0", Detail = "Name", TextColor = Color.OliveDrab };
            txtDtls[1] = new TextCell { Text = "0.0", Detail = "Last Price", TextColor = Color.DodgerBlue };
            txtDtls[2] = new TextCell { Text = "0.0", Detail = "Last Time", TextColor = Color.OliveDrab };
            txtDtls[3] = new TextCell { Text = "0.0", Detail = "Max", TextColor = Color.DodgerBlue };
            txtDtls[4] = new TextCell { Text = "0.0", Detail = "Min", TextColor = Color.OliveDrab };
            txtDtls[7] = new TextCell { Text = "0.0", Detail = "Best Bid", TextColor = Color.DodgerBlue };
            txtDtls[6] = new TextCell { Text = "0.0", Detail = "Best Ask", TextColor = Color.OliveDrab };
            txtDtls[5] = new TextCell { Text = "0.0", Detail = "Change %", TextColor = Color.DodgerBlue };

            myTable = new TableView
            {
                Intent = TableIntent.Data,
                Root = new TableRoot("Lightstreamer Xamarin Stock-List Demo") {
                    new TableSection ("Stock Details") {
                        txtDtls[0],
                        txtDtls[1],
                        txtDtls[2],
                        txtDtls[3],
                        txtDtls[4],
                        txtDtls[7],
                        txtDtls[6],
                        txtDtls[5]
                    }
                }
            };
            myTable.BackgroundColor = Color.Honeydew;
            

            txtDtls[0].SetBinding(TextCell.TextProperty, "DetailsName", BindingMode.OneWay);

            txtDtls[1].SetBinding(TextCell.TextProperty, "DetailsLast", BindingMode.OneWay);

            txtDtls[2].SetBinding(TextCell.TextProperty, "DetailsTime", BindingMode.OneWay);

            txtDtls[4].SetBinding(TextCell.TextProperty, "DetailsMin", BindingMode.OneWay);

            txtDtls[3].SetBinding(TextCell.TextProperty, "DetailsMax", BindingMode.OneWay);

            txtDtls[5].SetBinding(TextCell.TextProperty, "DetailsChg", BindingMode.OneWay);

            txtDtls[6].SetBinding(TextCell.TextProperty, "DetailsAsk", BindingMode.OneWay);

            txtDtls[7].SetBinding(TextCell.TextProperty, "DetailsBid", BindingMode.OneWay);

            Thickness padd = new Thickness(0);
            double scale = 1.0;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    padd = new Thickness(0, 20, 0, 0);
                    break;
                case Device.Android:
                    padd = new Thickness(15, 10);
                    break;
                case Device.UWP:
                    padd = new Thickness(75, 50);
                    myTable.Margin = new Thickness(25, 25);
                    scale = 1.2;
                    break;
            }
            detailsLayout = new StackLayout { Padding = padd, Scale = scale };
            detailsLayout.Children.Add(myTable);
            this.Content = detailsLayout;
        }

        private void EventPage_OnDisappearing(object sender, EventArgs e)
        {
            Debug.WriteLine("Disappeared");
            __myClass.UnSubscribeDetails();
        }
    }

}