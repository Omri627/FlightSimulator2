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
        private ISettingsModel model;           // model instance of settings
        private Window window;
        /**
         * constructor creates settings view model initialized with properties
         * the view model link between the presentation/view and model
        **/
        public SettingsWindowViewModel(ISettingsModel model, Window window)
        {
            this.model = model;
            this.window = window;
        }
        /**
         * FlightServerIP Property provides a flexible mechanism to set and get
         * the commands server ip
         **/
        public string FlightServerIP
        {
            get { return model.FlightServerIP; }
            set
            {
                /* set flight command server ip and notify all that the property has beenchanged */
                model.FlightServerIP = value;
                NotifyPropertyChanged("FlightServerIP");
            }
        }

        /**
         * FlightCommandPort Property provides a flexible mechanism to set and get
         * the commands server port
         **/
        public int FlightCommandPort
        {
            get { return model.FlightCommandPort; }
            set
            {
                /* set flight command port and notify all that the property has beenchanged */
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
                /* set info server port and notify all that the property has beenchanged */
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
        private ICommand _clickCommand;         // click command
        /**
         * ClickCommand Property provides a event handler which
         * set in data storage the settings received by user 
         **/ 
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => OnClick()));
            }
        }
        /**
         * OnClick method contains code to execute on click action.
         **/
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
