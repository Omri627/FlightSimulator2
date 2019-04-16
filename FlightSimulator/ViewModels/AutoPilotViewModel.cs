using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; // event when property changed
        private AutoPilotModel model;       // model instance of auto-pilot
        private string code;                // code received by user
        private string color;               // color indicate whether the code already executed
        /**
         * constructor creates auto pilot view model initialized with properties
         * the view model link between the presentation/view and model,
         * and consist the properties values received by server
         **/
        public AutoPilotViewModel()
        {
            model = new AutoPilotModel();
        }
        /**
         * Code Property provides a flexible mechanism to set and get the code property
         * code contains commands to execute by the flightgear server
         **/ 
        public string Code {
            get {
                return code;
            }
            set {
                code = value;
                /* changes the background if code is empty */
                if (code != string.Empty)
                    Color = "Salmon";
                else
                    Color = "White";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Code"));
            }
        }
        /**
        * Color Property provides a flexible mechanism to set and get the color property
        * color indicates the background color of text box.
        * light red (=slamon) indicates that the code didnt fully executed yet
        * whereas, white indicates that the code is already executed. 
        **/
        public string Color
        {
            get {
                /* get color property */
                return color;
            }
            set {
                /* set color property, and notify that property has been changed */
                color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Color"));
            }
        }
        #region Commands
        #region CancelCommand
        private ICommand _cancelCommand;    // cancel command
        /**
         * CancelCommand Property provides a event handler which
         * reset the code received by user.
         **/ 
        public ICommand CancelCommand
        {
            get {
                return _cancelCommand ?? (_cancelCommand = new CommandHandler(() => OnCancel()));
            }
        }
        /**
         * OnCancel method contains code executed on cancel action
         **/ 
        private void OnCancel()
        {
            Code = "";
            Color = "White";
        }
        #endregion
        #region
        private ICommand _okCommand;            // ok command
        /**
         * OkCommand Property provides a event handler which
         * send the user code to flightgear server, 
         * the flightgear application execute each command in code
         **/
        public ICommand OkCommand
        {
            get
            {
                return _okCommand ?? (_okCommand = new CommandHandler(() => OnOk()));
            }
        }
        /**
        * onOk method contains code executed on ok action
        **/
        private void OnOk()
        {
            new Thread(() =>
            {
                model.ExecuteCode(code);
                Color = "White";
            }).Start();
        }

        #endregion
        #endregion
    }
}
