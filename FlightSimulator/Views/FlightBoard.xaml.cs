using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for MazeBoard.xaml
    /// </summary>
    public partial class FlightBoard : UserControl
    {
        ObservableDataSource<Point> planeLocations = null;       // points data strcture
        FlightBoardViewModel viewModel;         // view mode lof flight board
        bool firstTime;                         // boolean variable used to indicate whether the first value 
                                                // recived from data-set 
        /**
         *  the constructor creates presentation of FlightBoard Control based on the xaml code
         *  and initialized his properties
         **/
        public FlightBoard()
        {
            InitializeComponent();
            DataContext = viewModel = new FlightBoardViewModel();
            viewModel.PropertyChanged += Vm_PropertyChanged;
            firstTime = false;
        }
        /**
         * UserControl_Loaded method adds points and prints the points
         * received from server on graph
         **/
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            planeLocations = new ObservableDataSource<Point>();
            // Set identity mapping of point in collection to point on plot
            planeLocations.SetXYMapping(p => p);

            plotter.AddLineGraph(planeLocations, 2, "Route");
        }
        /**
         * Vm_PropertyChanged method called whenever lat or lon changed.
         * and appends new points to data structure denote the location of plane in flightgear.
         **/
        private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            /* dont inserts values before the flight-gear is fully connected */
            if (firstTime == false)
            {
                firstTime = true;
                System.Threading.Thread.Sleep(500);
                return;
            }
            /* appends new points to data structure denote the location of plane in flightgear */
            if (e.PropertyName.Equals("Lat") || e.PropertyName.Equals("Lon"))
            {
                // create new point and add it to planeLocations
                Point p1 = new Point(viewModel.Lat, viewModel.Lon);
                planeLocations.AppendAsync(Dispatcher, p1);
            }
        }

    }

}

