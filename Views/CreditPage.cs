using System.Windows.Input;

namespace GPSTrackerNYIT.Views
{
    public partial class CreditPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public CreditPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
