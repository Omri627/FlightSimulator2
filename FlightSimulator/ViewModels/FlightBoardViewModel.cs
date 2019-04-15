using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Views.Windows;
using System.Threading;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify, INotifyPropertyChanged
    {
        private bool isConnected;
        private FlightModel model;
        private SymbolTable symbolTable;
        public event PropertyChangedEventHandler PropertyChanged;
        public FlightBoardViewModel() {
            model = new FlightModel();
            symbolTable = SymbolTable.Instance;
            symbolTable.PropertyChanged += delegate (object sender, PropertyChangedEventArgs args)
            {
                PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(args.PropertyName));
            };
            IsConnected = false;
        }
       public bool IsConnected {
            get
            {
                return isConnected;
            }
            set
            {
                isConnected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsConnected"));
            }
        }
        public double Lon
        {
            get
            {
                return symbolTable[SymbolTable.LONGITUDE_DEG];
            }
        }

        public double Lat
        {
            get
            {
                return symbolTable[SymbolTable.LATITUDE_DEG];
            }
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
            IsConnected = true;
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
        #region ExitCommand
        private ICommand _exitCommand;

        public ICommand ExitCommand
        {
            get
            {
                return _exitCommand ?? (_exitCommand = new CommandHandler(() => onExit()));
            }
        }
        private void onExit()
        {
            model.DisconnectServers();
            IsConnected = false;
        }
        #endregion
        #endregion

    }
}
