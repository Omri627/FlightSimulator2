using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ManualModel
    {
        private CommandsServer server;          // command server instance 
        /**
         * ManualModel creates manual model instance
         * the model responsible for manual logics and contains methods which performs
         * complex calculations and operations
         **/ 
        public ManualModel()
        {
            server = CommandsServer.Instance;
        }
        /**
         * SetProperty method gets property name and value,
         * and update the property value in flight-gear application
         **/
        public void SetProperty(string property, double value)
        {
            string command = "set " + property + " " + value + "\r\n";
            server.Write(command);
        }
    } 
}
