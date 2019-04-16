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
        protected bool stop;            // indicate whether application stop reading data from server
        protected TcpClient client;     // tcp client data
        /**
         * ConnectToServer method connect to flightgear server in given ip and port.
         **/
        public abstract void connectToServer();
        /**
         *  closeConnection method close the connection to flightgear server.
         **/
        public abstract void closeConnection();
        /**
         * Stop property provides a flexible mechanism to get and set stop member value.
         * stop indicates whether the application stop receive data from server or keep on reading
         **/
        public bool Stop
        {
            get
            {
                /* get stop value */
                return stop;
            }
            set
            {
                /* changes stop value */
                stop = value;
            }
        }
        /**
         * Write method gets a command as parameter 
         * and send this message to connected server
         **/ 
        public bool Write(string command)
        {
            if (client == null || !client.Connected)
                return false;
            NetworkStream stream = client.GetStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(Encoding.ASCII.GetBytes(command));
            return true;
        }
        /**
         * Read method reads data contains the properties values from connected server.
         **/
        public string Read()
        {
            char[] data = new char[512];                   // message recevied from server
            int index = 0;                                 // the number of characters already read
            char ch;                                       // current character
            /* if server is not connected return an empty string */
            if (client == null || !client.Connected)
                return string.Empty;
            NetworkStream stream = client.GetStream();          // socket stream from server
            BinaryReader reader = new BinaryReader(stream);     // reader from server
            try
            {
                /* reads single-string data from server */
                while ((ch = reader.ReadChar()) != '\n')
                    data[index++] = ch;
            } catch(Exception)
            {
                /* in case server disconnected or there is error in reading data from server */
                Stop = false;
                closeConnection();
                return string.Empty;
            }
            data[index - 1] = '\0';
            return new string(data, 0, index - 1);
        }
    }
}
