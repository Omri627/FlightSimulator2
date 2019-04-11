using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private double rudder;
        private double elevator;
        private double throttle;
        private double aileron;
        public FlightBoardViewModel()
        {
            rudder = 0.25;
            elevator = 0.35;
            throttle = 0.45;
            aileron = 0.55;
        }
        public double Rudder
        {
            get  {
                return rudder;
            }
            set {
                if (value >= 0 && value <= 1)
                    rudder = value;
            }
        }
        public double Elevator
        {
            get  {
                return elevator;
            }
            set  {
                if (value >= 0 && value <= 1)
                    elevator = value;
            }
        }
        public double Throttle
        {
            get {
                return throttle;
            }
            set
            {
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
        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }
        #region
        private ICommand _connectCommand;
        private Server server;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand =
                new CommandHandler(() => OnClick()));
            }
        }
        private void OnClick()
        {
            server = new Server(5400);
            server.connectToServer();
            
            //IsDisconnected = false;             // Setting that the server is
        }
    #endregion
    }
}
