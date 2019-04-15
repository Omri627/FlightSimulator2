using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace FlightSimulator.Model
{
    abstract class Server
    {
        protected bool stop;
        protected TcpClient client;
        public abstract void connectToServer();
        public abstract void closeConnection();
        public bool Stop
        {
            get
            {
                return stop;
            }
            set
            {
                stop = value;
                if (value == false)
                    closeConnection();
            }
        }
        public bool Write(string command)
        {
            if (client == null || !client.Connected)
                return false;
            NetworkStream stream = client.GetStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(Encoding.ASCII.GetBytes(command));
            return true;
        }
        public string read()
        {
            int index = 0;
            char ch;
            char[] data = new char[512];                   // message recevied from server
            if (client == null || !client.Connected)
                return string.Empty;
            NetworkStream stream = client.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            try
            {
                while ((ch = reader.ReadChar()) != '\n')
                    data[index++] = ch;
            } catch(Exception ex)
            {
                Stop = false;
                return string.Empty;
            }
            data[index - 1] = '\0';
            return new string(data, 0, index - 1);
        }
    }
}
