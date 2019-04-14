using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class ManualViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ManualModel model;
        private double rudder;
        private double aileron;
        private double elevator;
        private double throttle;
        public ManualViewModel() {
            model = new ManualModel();
        }
        public double Rudder
        {
            get {
                return rudder;
            }
            set {
                if (value >= -1 && value <= 1)
                {
                    rudder = value;
                    model.SetProperty(SymbolTable.RUDDER, rudder);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Rudder"));
                }
            }
        }
        public double Throttle
        {
            get {
                return throttle;
            }
            set {
                if (value >= 0 && value <= 1)
                {
                    throttle = value;
                    model.SetProperty(SymbolTable.THROTTLE, throttle);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Throttle"));
                }
            }
        }
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                if (value >= -1 && value <= 1)
                {
                    aileron = value;
                    model.SetProperty(SymbolTable.AILERON, aileron);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Aileron"));
                }
            }
        }
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                if (value >= -1 && value <= 1)
                {
                    elevator = value;
                    model.SetProperty(SymbolTable.ALEVATOR, elevator);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Elevator"));
                }
            }
        }


        #region Commands
        #region ThrottleSliderCommand
        private ICommand _throttleSliderCommand;
        public ICommand ThrottleSliderCommand
        {
            get
            {
                return _throttleSliderCommand ?? (_throttleSliderCommand = new CommandHandler(() => OnThrottleSliderChnage()));
            }
        }
        private void OnThrottleSliderChnage()
        {
            model.SetProperty(SymbolTable.THROTTLE, throttle);
        }
        #endregion
        #region ThrottleSliderCommand
        private ICommand _rudderSliderCommand;
        public ICommand RudderSliderCommand
        {
            get
            {
                return _rudderSliderCommand ?? (_rudderSliderCommand = new CommandHandler(() => OnRudderSliderChnage()));
            }
        }
        private void OnRudderSliderChnage()
        {
            model.SetProperty(SymbolTable.RUDDER, rudder);
        }
        #endregion
        #endregion



    }
}