using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class ManualViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double rudder;
        private double elevator;
        private double throttle;
        private double aileron;
        public ManualViewModel() {

        }
        public double Rudder
        {
            get {
                return rudder;
            }
            set {
                if (value >= 0 && value <= 1)
                {
                    rudder = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Rudder"));
                }
            }
        }
        public double Elevator
        {
            get {
                return elevator;
            }
            set {
                if (value >= 0 && value <= 1)
                {
                    elevator = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Elevator"));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Throttle"));
                }
            }
        }
        public double Aileron
        {
            get {
                return aileron;
            }
            set {
                if (value >= 0 && value <= 1)
                {
                    aileron = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Aileron"));
                }
            }
        }
    }
}