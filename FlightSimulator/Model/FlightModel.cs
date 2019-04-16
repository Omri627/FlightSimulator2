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
        private InfoServer info_server;             // flightgear info server
        private CommandsServer commands_server;     // flightgear command server 
        private ISettingsModel model;               // model instance of settings 
        /**
         * FlightModel creates flight-board model instance
         * the model responsible for flight logics and contains methods which performs
         * complex calculations and operations
         **/ 
        public FlightModel()
        {
            model = ApplicationSettingsModel.Instance;
        }
        /**
        * ConnectInfoServer methods connect to info-server in asychronized mode
        * whenever the server connected, the application continiously reads data from server
        * and update data set symbol table which contains all the properties values from server
        **/
        public void ConnectInfoServer()
        {
            if (info_server != null && commands_server != null)
                return;
            info_server = new InfoServer(model.FlightInfoPort);
            info_server.connectToServer();
            info_server.ReadDataContinously();
        }
        /**
        * ConnectCommandsServer methods connect to commands-server in asychronized mode
        * this connection enable the user to set properties in flight-gear application
        **/
        public void ConnectCommandsServer()
        {
            if (commands_server != null)
                return;
            commands_server = CommandsServer.Instance;
            commands_server.connectToServer();
        }
        /**
         * DisconnectServers method disconnect from info server and commands server
         **/
        public void DisconnectServers()
        {
            commands_server.closeConnection();
            info_server.closeConnection();
        }
    }
}
