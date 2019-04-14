using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ManualModel
    {
        private CommandsServer server;
        public ManualModel()
        {
            server = CommandsServer.Instance;
        }
        public void SetProperty(string property, double value)
        {
            string command = "set " + property + " " + value + "\r\n";
            server.Write(command);
        }
    }
}
