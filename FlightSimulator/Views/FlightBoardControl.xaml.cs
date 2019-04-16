using System;
using System.Collections.Generic;
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
using FlightSimulator.ViewModels;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for FlightBoardControl.xaml
    /// </summary>
    public partial class FlightBoardControl : UserControl
    {
        private FlightBoardViewModel vm;
        /**
        *  the constructor creates presentation of FlightBoard Control based on the xaml code
        *  and initialized his properties
        **/
        public FlightBoardControl()
        {
            InitializeComponent();
            vm = new FlightBoardViewModel();
            /* changes the data context to view model */
            DataContext = vm;
        }
    }
}
