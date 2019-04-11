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
    class Server
    {
        private int port;
        private TcpClient client;
        private TcpListener listener;
        public Server(int port)  {
            this.port = port;
        }
        public void connectToServer()  {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);
            listener.Start(5);
            Console.WriteLine("Waiting for client connections...");
            client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");
        }
        public bool write(string command) {
            if (!client.Connected)
                return false;
            NetworkStream stream = client.GetStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(command);
            return true;
        }
        public string read()  {
            int index = 0;
            char ch;
            char[] data = new char[512];                   // message recevied from server
            NetworkStream stream = client.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            while ((ch = reader.ReadChar()) != '\n')
                data[index++] = ch;
            data[index-1] = '\0';
            string str =  new string(data, 0, index-1);
            return str;
        }
        public void closeConnection()  {
            client.Close();
            listener.Stop();
        }
    }
}
