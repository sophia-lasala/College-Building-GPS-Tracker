using System.Windows.Input;

namespace GPSTrackerNYIT.Views
{
    public partial class VideoPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public VideoPage()
        {
            InitializeComponent();
            BindingContext = this;

            string htmlContent = @"
            <html>
            <body style='margin:0;padding:0;background-color:black;'>
                <video width='100%' height='100%' controls autoplay>
                    <source src='https://www.w3schools.com/html/mov_bbb.mp4' type='video/mp4'>
                    Your browser does not support the video tag.
                </video>
            </body>
            </html>";

            VideoWebView.Source = new UrlWebViewSource
            {
                Url = "annarubin_video.mp4"
            };
        }
    }
}
