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
        private bool isConnected;          // boolean variable indicate whether the server is connected or not
        private FlightModel model;         // instance of flight board model
        private SymbolTable symbolTable;   // data structure contains the properties of flight gear 
        public event PropertyChangedEventHandler PropertyChanged;
        /**
         * constructor creates flight board view model initialized with properties
         * the view model link between the presentation/view and model,
         * and consist the properties values received by server
         **/
        public FlightBoardViewModel() {
            model = new FlightModel();
            symbolTable = SymbolTable.Instance;
            symbolTable.PropertyChanged += delegate (object sender, PropertyChangedEventArgs args)
            {
                if (args.PropertyName == "EnableConnect")
                    IsConnected = false;
                PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(args.PropertyName));
            };
            IsConnected = false;

        }
        /**
         * IsConnected Property provides a flexible mechanism to set and get
         * isConnected member value.
         * is connected indicate whether the server is connected or not.
         **/ 
       public bool IsConnected {
            get
            {
                return isConnected;
            }
            set
            {
                isConnected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EnableConnect"));
            }
        }
        /**
         * EnableConnect Property provides flexible machanism to get indication 
         * if the user can connect or not.
         **/
        public bool EnableConnect
        {
            get
            {
                return !isConnected;
            }
        }
        /**
         * Lon Property provides a flexible mechanism to set and get 
         * lon member value
         * lon is the angle between the planes parallel to the earth axis and passing through
         * the Greenwich Meridian respectively the point designated by the coordinates.
         **/
        public double Lon
        {
            get
            {
                /* get lon value */
                return symbolTable[SymbolTable.LONGITUDE_DEG];
            }
        }

        public double Lat
        {
            get
            {
                /* get lat value */
                return symbolTable[SymbolTable.LATITUDE_DEG];
            }
        }
        #region Commands
        #region ConnectCommand
        private ICommand _connectCommand;           // connect command instance
        /**
         * ConnectCommand Property provides a event handler which
         * connect to the flightgear server.
         * info server continously read data from server
         * and enable user to set values.
         **/ 
        public ICommand ConnectCommand
        {
            get {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnConnect()));
            }
        }
        /**
         * OnConnect method contains code to execute on connect action
         **/
        private void OnConnect()
        {
            Thread infoServerThread, commandsServerThread;      // threads to connect servers
            /* connect to info server, run in aychornizous mode */
            infoServerThread = new Thread(new ThreadStart(model.ConnectInfoServer));
            infoServerThread.Start();
            /* connect to commands server, run in aychornizous mode */
            commandsServerThread = new Thread(new ThreadStart(model.ConnectCommandsServer));
            commandsServerThread.Start();
            IsConnected = true;
        }
        #endregion
        #region SettingsCommand
        private ICommand _settingCommand;   // setting command instance
        /**
        * SettingCommand Property provides a event handler which
        * open settings window
        * settings window enable users to set ip and ports of connection
        **/
        public ICommand SettingCommand
        {
            get {
                return _settingCommand ?? (_settingCommand = new CommandHandler(() => onSettings()));
            }
        }
        /**
         * onSettings method contains code to execute on settings action
         **/
        private void onSettings()
        {
            /* open settings window */
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }
        #endregion
        #region ExitCommand
        private ICommand _exitCommand;      // exit command instance
        /**
         * ExitCommand Property provides a event handler which
         * disconnect from flightgear servers when close the window
         **/ 
        public ICommand ExitCommand
        {
            get
            {
                return _exitCommand ?? (_exitCommand = new CommandHandler(() => onExit()));
            }
        }
        /**
         * onExit method contains code to execute on exit action 
         **/
        private void onExit()
        {
            model.DisconnectServers();
            IsConnected = false;
        }
        #endregion
        #endregion

    }
}
