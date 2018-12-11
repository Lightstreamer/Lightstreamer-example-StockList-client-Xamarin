using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace XDemo5
{
    public class AboutViewModel 
    {
        public AboutViewModel()
        {
          
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://github.com/Lightstreamer/Lightstreamer-example-StockList-client-Xamarin")));
        }

        public ICommand OpenWebCommand { get; }
    }
}
