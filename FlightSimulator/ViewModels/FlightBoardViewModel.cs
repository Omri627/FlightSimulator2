using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;
using FlightSimulator.Views.Windows;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private Server server;
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
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnConnect()));
            }
        }
        private void OnConnect()
        {
            server = new Server(5400);
            server.connectToServer();
        }
        #endregion
        #region SettingsCommand
        private ICommand _settingCommand;
        public ICommand SettingCommand
        {
            get
            {
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
