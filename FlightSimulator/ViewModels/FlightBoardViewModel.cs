﻿using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Views.Windows;
using System.Threading;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightModel model;
        public FlightBoardViewModel() {
            model = new FlightModel();
        }
        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }
        #region Commands
        #region ConnectCommand
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnConnect()));
            }
        }
        private void OnConnect()
        {
            Thread infoServerThread, commandsServerThread;
            infoServerThread = new Thread(new ThreadStart(model.ConnectInfoServer));
            infoServerThread.Start();
            commandsServerThread = new Thread(new ThreadStart(model.ConnectCommandsServer));
            commandsServerThread.Start();
        }
        #endregion
        #region SettingsCommand
        private ICommand _settingCommand;
        public ICommand SettingCommand
        {
            get {
                return _settingCommand ?? (_settingCommand = new CommandHandler(() => onSettings()));
            }
        }
        private void onSettings()
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }
        #endregion
        #endregion

    }
}
