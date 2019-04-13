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
        private InfoServer info_server;
        private CommandsServer commands_server;
        private ISettingsModel model;
        public FlightModel()
        {
            model = ApplicationSettingsModel.Instance;
        }
        public void connectToServers()
        {
            if (info_server != null && commands_server != null)
                return;
            info_server = new InfoServer(5400);
            info_server.connectToServer();
            //info_server.write("write a message: ");
            string message = info_server.read();
            info_server.closeConnection();
            /*if (commands_server != null)
                return;
            commands_server = new CommandsServer(model.FlightServerIP, model.FlightCommandPort);
            commands_server.connectToServer();
            commands_server.write("set rudder");
            commands_server.closeConnection(); */
        }
    }
}
