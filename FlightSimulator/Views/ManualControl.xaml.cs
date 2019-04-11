﻿using System;
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
    /// Interaction logic for ManualControl.xaml
    /// </summary>
    public partial class ManualControl : UserControl
    {
        public FlightBoardViewModel vm;
        public ManualControl()
        {
            InitializeComponent();
            vm = new FlightBoardViewModel();
            this.DataContext = vm;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
