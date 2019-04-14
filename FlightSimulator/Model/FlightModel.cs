using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public void ConnectInfoServer()
        {
            if (info_server != null && commands_server != null)
                return;
            info_server = new InfoServer(model.FlightInfoPort);
            info_server.connectToServer();
            info_server.StartReadDataContinously();
        }
        public void ConnectCommandsServer()
        {
            if (commands_server != null)
                return;
            commands_server = CommandsServer.Instance;
            commands_server.connectToServer();
        }
    }
}
