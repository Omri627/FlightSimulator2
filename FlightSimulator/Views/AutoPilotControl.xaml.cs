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
    /// Interaction logic for AutoPilotControl.xaml
    /// </summary>
    public partial class AutoPilotControl : UserControl
    {
        private AutoPilotViewModel vm;          // auto pilot view model instance
        /**
         *  the constructor creates presentation of AutoPilot Control based on the xaml code
         *  and initialized his properties
         **/
        public AutoPilotControl()
        {
            InitializeComponent();
            vm = new AutoPilotViewModel();      
            /* changes the data context to view model */
            DataContext = vm;
        }
    }
}
