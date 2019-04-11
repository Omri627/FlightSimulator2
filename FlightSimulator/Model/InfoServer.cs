using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlightSimulator.Model
{
    class InfoServer : Server
    {
        private int port;
        private TcpListener listener;
        public InfoServer(int port)  {
            this.port = port;
        }
        public override void connectToServer()  {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);
            listener.Start(5);
            Console.WriteLine("Waiting for client connections...");
            client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");
        }
        public override void closeConnection()  {
            client.Close();
            listener.Stop();
        }
    }
}
