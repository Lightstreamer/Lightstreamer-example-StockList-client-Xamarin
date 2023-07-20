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

using System.Diagnostics;
using Xamarin.Forms;

namespace XDemo5
{
    public partial class MainPage : ContentPage
    {

        private static RTfeed _myClass;
        private static StackLayout layout;
        TextCell[] txtStock;
        TableView myTable;
        TextCell txtStatusLbl;

        public MainPage(RTfeed f)
        {
            InitializeComponent();

            _myClass = f;

            var ti = new ToolbarItem();
            ti.Text = "About";
            ti.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new AboutPage());
                Debug.WriteLine("About Page.");
            };
            ToolbarItems.Add(ti);

            BindingContext = _myClass;

            txtStatusLbl = new TextCell { Text = "Lightstreamer is connecting ... ", TextColor = Color.Orange };
            txtStock = new TextCell[6];

            txtStock[0] = new TextCell { Text = "0.0", Detail = "...", TextColor = Color.OliveDrab, Command = new Command(() => Navigation.PushAsync(new DetailsPage(_myClass, 2))) };
            txtStock[1] = new TextCell { Text = "0.0", Detail = "...", TextColor = Color.DodgerBlue, Command = new Command(() => Navigation.PushAsync(new DetailsPage(_myClass, 7))) };
            txtStock[2] = new TextCell { Text = "0.0", Detail = "...", TextColor = Color.OliveDrab, Command = new Command(() => Navigation.PushAsync(new DetailsPage(_myClass, 11))) };
            txtStock[3] = new TextCell { Text = "0.0", Detail = "...", TextColor = Color.DodgerBlue, Command = new Command(() => Navigation.PushAsync(new DetailsPage(_myClass, 18))) };
            txtStock[4] = new TextCell { Text = "0.0", Detail = "...", TextColor = Color.OliveDrab, Command = new Command(() => Navigation.PushAsync(new DetailsPage(_myClass, 22))) };
            txtStock[5] = new TextCell { Text = "0.0", Detail = "...", TextColor = Color.DodgerBlue, Command = new Command(() => Navigation.PushAsync(new DetailsPage(_myClass, 27))) };
            myTable = new TableView
            {
                Intent = TableIntent.Data,
                Root = new TableRoot("Lightstreamer Xamarin Stock-List Demo") {
                    new TableSection ("Stocks") {
                        txtStock[0],
                        txtStock[1],
                        txtStock[2],
                        txtStock[3],
                        txtStock[4],
                        txtStock[5],
                        txtStatusLbl,
                    }
                }
            };
            myTable.BackgroundColor = Color.LightGoldenrodYellow;
            
            Thickness padd = new Thickness(0) ;
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

            txtStock[0].SetBinding(TextCell.TextProperty, "LabelText0", BindingMode.TwoWay);
            txtStock[0].SetBinding(TextCell.DetailProperty, "DescText0", BindingMode.TwoWay);
            
            txtStock[1].SetBinding(TextCell.TextProperty, "LabelText1", BindingMode.TwoWay);
            txtStock[1].SetBinding(TextCell.DetailProperty, "DescText1", BindingMode.TwoWay);
            
            txtStock[2].SetBinding(TextCell.TextProperty, "LabelText2", BindingMode.TwoWay);
            txtStock[2].SetBinding(TextCell.DetailProperty, "DescText2", BindingMode.TwoWay);

            txtStock[3].SetBinding(TextCell.TextProperty, "LabelText3", BindingMode.TwoWay);
            txtStock[3].SetBinding(TextCell.DetailProperty, "DescText3", BindingMode.TwoWay);

            txtStock[4].SetBinding(TextCell.TextProperty, "LabelText4", BindingMode.TwoWay);
            txtStock[4].SetBinding(TextCell.DetailProperty, "DescText4", BindingMode.TwoWay);

            txtStock[5].SetBinding(TextCell.TextProperty, "LabelText5", BindingMode.TwoWay);
            txtStock[5].SetBinding(TextCell.DetailProperty, "DescText5", BindingMode.TwoWay);

            txtStatusLbl.SetBinding(TextCell.TextProperty, "StatusText", BindingMode.TwoWay);
            txtStatusLbl.SetBinding(TextCell.TextColorProperty, "StatusColor", BindingMode.TwoWay);

            layout = new StackLayout { Padding = padd, Scale = scale };

            layout.Children.Add(myTable);
            
            this.Content = layout;

        }
    }
}
