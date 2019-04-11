using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Model
{
    class FlightModel
    {
        private Server server;
        private ISettingsModel model;
        public FlightModel()
        {
            model = ApplicationSettingsModel.Instance;
        }
        public void connectToServers()
        {
            if (server != null)
                return;
            server = new Server(model.FlightCommandPort);
            server.connectToServer();
            server.write("write a message: ");
            string message = server.read();
            server.closeConnection();
        }
    }
}
