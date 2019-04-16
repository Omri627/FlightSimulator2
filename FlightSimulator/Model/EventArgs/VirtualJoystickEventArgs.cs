using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model.EventArgs
{
    public class VirtualJoystickEventArgs
    {
        /**
         * Aileron Property provides a flexible mechanism to
         * set and get aileron member value
         **/
        public double Aileron { get; set; }
        /**
         * Elevator Property provides a flexible mechanism to
         * set and get his elevator member vlaue
         **/
        public double Elevator { get; set; }
    }
}
