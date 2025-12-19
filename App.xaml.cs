using Microsoft.Extensions.DependencyInjection;
using GPSTrackerNYIT.Views;

namespace GPSTrackerNYIT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        public static HistoryManager HistoryManager { get; } = new HistoryManager();

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
