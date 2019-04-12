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
using System.Windows.Shapes;
using FlightSimulator.Model;
using FlightSimulator.ViewModels;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string s ="0.1, 0.2, 1.1";
            
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            InfoServer server = new InfoServer(5400);
            server.connectToServer();
            //SettingButton.Content = "connect pressed";
            server.write("write a message: ");
            string message = server.read();
            //ConnectButton.Content = message;
        }
        
    }
}
