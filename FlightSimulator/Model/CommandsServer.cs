using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using FlightSimulator.Model.Interface;

namespace FlightSimulator.Model
{
    class CommandsServer : Server
    {
        private int port;
        private string ip;
        private CommandsServer(string ip,int port)
        {
            this.ip = ip;
            this.port = port;
        }
        #region
        private static CommandsServer instance = null;
        public static CommandsServer Instance
        {
            get
            {
                ISettingsModel settingsModel = ApplicationSettingsModel.Instance;
                if (instance == null)
                    instance = new CommandsServer(settingsModel.FlightServerIP, settingsModel.FlightCommandPort);
                return instance;
            }
        }
        #endregion
        public override void connectToServer()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), 5400);
            client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");
        }
        public override void closeConnection()
        {
            client.Close();
        }

    }
}
