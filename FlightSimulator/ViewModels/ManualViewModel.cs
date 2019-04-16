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
        public event PropertyChangedEventHandler PropertyChanged;   // event execute when property changed
        private ManualModel model;      // model instance of manual 
        private double rudder;          // rudder property of flight
        private double aileron;         // aileron property of flight
        private double elevator;        // elevator property of flight
        private double throttle;        // throttle property of flight
        /**
         * constructor creates manual view model initialized with properties values
         * the view model link between the presentation/view and model,
         * and consist the properties values received by server
         **/
        public ManualViewModel() {
            model = new ManualModel();
        }
        /**
         * Rudder Property provides flexible mechanism to set and get rudder value
         * The rudder is attached to the fin which allows the pilot to control yaw in the vertical axis.
         **/
        public double Rudder
        {
            get {
                /* get rudder value */
                return rudder;
            }
            set {
                /* set rudder property and changes the value in flightgear server */
                if (value >= -1 && value <= 1)
                {
                    rudder = value;
                    model.SetProperty(SymbolTable.RUDDER, rudder);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Rudder"));
                }
            }
        }
        /**
         * Throttle Property provides flexible mechanism to set and get throttle value
         * throttle is a device controlling the flow of fuel or power to an engine.
         **/
        public double Throttle
        {
            get {
                /* get throttle value */
                return throttle;
            }
            set {
                /* set throttle property and changes the value in flightgear server */
                if (value >= 0 && value <= 1)
                {
                    throttle = value;
                    model.SetProperty(SymbolTable.THROTTLE, throttle);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Throttle"));
                }
            }
        }
        /**
         * Aileron Property provides flexible mechanism to set and get rudder value
         * Ailerons are hinged control surfaces attached to the trailing edge of the wing of a fixed-wing aircraft.
         **/
        public double Aileron
        {
            get
            {
                /* get aileron value */
                return aileron;
            }
            set
            {
                /* set aileron property and changes the value in flightgear server */
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
                /* get elevator value */
                return elevator;
            }
            set
            {
                /* set rudder property and changes the value in flightgear server */
                if (value >= -1 && value <= 1)
                {
                    elevator = value;
                    model.SetProperty(SymbolTable.ELEVATOR, elevator);
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