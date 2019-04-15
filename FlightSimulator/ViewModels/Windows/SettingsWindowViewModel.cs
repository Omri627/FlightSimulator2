using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.Windows
{
    public class SettingsWindowViewModel : BaseNotify
    {
        private ISettingsModel model;
        private Window window;
        /**
         * constructor
         **/
        public SettingsWindowViewModel(ISettingsModel model, Window window)
        {
            this.model = model;
            this.window = window;
        }
        /**
         * prperty of the flight server ip
         **/
        public string FlightServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }
        /**
         * prperty of the flight command server port
         **/
        public int FlightCommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                model.FlightCommandPort = value;
                NotifyPropertyChanged("FlightCommandPort");
            }
        }
        /**
         * prperty of the flight info server port
         **/
        public int FlightInfoPort
        {
            get { return model.FlightInfoPort; }
            set
            {
                model.FlightInfoPort = value;
                NotifyPropertyChanged("FlightInfoPort");
            }
        }
        /**
         * save the setting to the app.config
         **/
        public void SaveSettings()
        {
            model.SaveSettings();
        }
        /**
         * reload the setting of the app.config, not saving them
         **/
        public void ReloadSettings()
        {
            model.ReloadSettings();
        }

        #region Commands
        #region ClickCommand
        
        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            //save the settings and close the settings window
            model.SaveSettings();
            window.Close();
        }
        #endregion

        #region CancelCommand
        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => OnCancel()));
            }
        }
        private void OnCancel()
        {
            //not save the settings and close the settings window
            model.ReloadSettings();
            window.Close();
        }
        #endregion
        #endregion
    }
}
