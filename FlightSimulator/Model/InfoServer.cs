using System;
using System.Net;
using System.Net.Sockets;
using FlightSimulator.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace FlightSimulator.Model
{
    class InfoServer : Server {
        private bool isListening;
        private int port;
        private TcpListener listener;
        private SymbolTable symbolTable;
        public InfoServer(int port) {
            this.port = port;
            symbolTable = SymbolTable.Instance;
            Stop = false;
            isListening = false;
        }
        public bool Stop { get; set; }
        public override void connectToServer()  {
            if (isListening == true || client != null)
                return;
            isListening = true;
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);
            listener.Start(5);
            Console.WriteLine("Waiting for client connections...");
            client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");
        }
        public override void closeConnection()  {
            Stop = true;
            client.Close();
            listener.Stop();
            client = null;
        }
        public void ReadDataContinously()
        {
            string data;                            // data received from server
            while (Stop == false)
            {
                data = read();
                symbolTable.UpdateData(data);
            }
        }
    }
}
