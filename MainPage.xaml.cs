using System.Runtime.ExceptionServices;

namespace Scanner
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            barcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
            {
               Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
               AutoRotate = true,
               Multiple = true
            };
        }

        private void barcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            var first = e.Results?.FirstOrDefault();
            
            if (first is null)
                return;

            Dispatcher.Dispatch(async () =>
            {
                await DisplayAlert("Detected", first.Value, "OK");
            });
        }
    }

}
