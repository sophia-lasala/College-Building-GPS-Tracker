using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GPSTrackerNYIT.Drawing;   // Needed for CoordinateGridDrawable

namespace GPSTrackerNYIT.Views
{
    public partial class MapPage : ContentPage, INotifyPropertyChanged
    {
        // ----------------------------------------------------
        // Picker-bound properties
        // ----------------------------------------------------

        private string _selectedStartLocation;
        public string SelectedStartLocation
        {
            get => _selectedStartLocation;
            set
            {
                if (_selectedStartLocation != value)
                {
                    _selectedStartLocation = value;
                    OnPropertyChanged();
                    ComputeRoute();
                }
            }
        }

        private string _selectedEndLocation;
        public string SelectedEndLocation
        {
            get => _selectedEndLocation;
            set
            {
                if (_selectedEndLocation != value)
                {
                    _selectedEndLocation = value;
                    OnPropertyChanged();
                    ComputeRoute();
                }
            }
        }

        private string _directionsText;
        public string DirectionsText
        {
            get => _directionsText;
            set
            {
                _directionsText = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> AvailableLocations { get; set; }

        // Graph engine
        private Graph _buildingGraph;
        private Direction _directionBuilder;

        public ICommand TapCommand =>
            new Command<string>(async (url) => await Launcher.OpenAsync(url));

        // ----------------------------------------------------
        // Constructor
        // ----------------------------------------------------
        public MapPage()
        {
            InitializeComponent();

            // Build the graph structure (nodes + edges)
            _buildingGraph = new Graph();
            _buildingGraph.InitializeBuilding();

            _directionBuilder = new Direction();

            // All node names from the graph go into both dropdowns
            AvailableLocations = new ObservableCollection<string>(
                _buildingGraph.GetAllNodes().Keys
            );

            DirectionsText = "Select start and end locations.";

            BindingContext = this;
        }

        // ----------------------------------------------------
        // Main Logic — Compute Route When Either Picker Changes
        // ----------------------------------------------------
        private void ComputeRoute()
        {
            if (string.IsNullOrWhiteSpace(SelectedStartLocation) ||
                string.IsNullOrWhiteSpace(SelectedEndLocation))
            {
                DirectionsText = "Please select both start and end locations.";
                return;
            }

            if (SelectedStartLocation == SelectedEndLocation)
            {
                DirectionsText = "You're already at the destination.";
                CoordinateGridDrawable.Instance.CurrentPath = new List<Node>();
                GraphOverlay.Invalidate();
                return;
            }

            try
            {
                // Run Dijkstra
                var path = Dijkstra.FindShortestPath(
                    _buildingGraph,
                    SelectedStartLocation,
                    SelectedEndLocation
                );

                // Save history (path already computed — no rerun needed)
                App.HistoryManager.AddEntry(
                    SelectedStartLocation,
                    SelectedEndLocation,
                    path
                );

                // Build readable steps
                var steps = _directionBuilder.BuildDirections(path);

                DirectionsText = string.Join("\n", steps);

                // --- SEND PATH TO DRAWABLE ---
                CoordinateGridDrawable.Instance.CurrentPath = path;

                // Refresh graphics overlay
                GraphOverlay.Invalidate();
            }
            catch (Exception ex)
            {
                DirectionsText = $"Error computing route: {ex.Message}";
            }
        }

        // ----------------------------------------------------
        // INotifyPropertyChanged Kernel
        // ----------------------------------------------------
        public new event PropertyChangedEventHandler PropertyChanged;

        protected new void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
