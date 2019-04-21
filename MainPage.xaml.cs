using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace CodigoQR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked (object sender, EventArgs e)
        {
            Scanner();
        }

        private async void Scanner()
        {
            var scannerPage = new ZXingScannerPage();
            scannerPage.Title = "Lector de QR prron";
            scannerPage.OnScanResult += (result) =>
            {
                scannerPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                    DisplayAlert("Si escaneó we :v", "", "OK");
                    codigo.Text = result.Text;
                });
            };
            await Navigation.PushAsync(scannerPage);
        }
    }
}