using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class ManualViewModel
    {
        private double rudder;
        private double elevator;
        private double throttle;
        private double aileron;
        public ManualViewModel() {
            rudder = 0.25;
            elevator = 0.35;
            throttle = 0.45;
            aileron = 0.55;
        }
        public double Rudder
        {
            get {
                return rudder;
            }
            set {
                if (value >= 0 && value <= 1)
                    rudder = value;
            }
        }
        public double Elevator
        {
            get {
                return elevator;
            }
            set {
                if (value >= 0 && value <= 1)
                    elevator = value;
            }
        }
        public double Throttle
        {
            get {
                return throttle;
            }
            set {
                if (value >= 0 && value <= 1)
                    throttle = value;
            }
        }
        public double Aileron
        {
            get {
                return aileron;
            }
            set {
                if (value >= 0 && value <= 1)
                    aileron = value;
            }
        }
    }
}
