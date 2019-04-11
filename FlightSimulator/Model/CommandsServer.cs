using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace FlightSimulator.Model
{
    class CommandsServer : Server
    {
        private int port;
        private string ip;
        public CommandsServer(string ip,int port)
        {
            this.ip = ip;
            this.port = port;
        }
        public override void connectToServer()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), 8000);
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
