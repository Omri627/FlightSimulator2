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
        private int port;           // port number of the connection
        private string ip;          // ip-address of the connection
        /**
         * the constructor creates new commands server.
         * the class contins methods to handle server: connect, disconnect, read and send messages
         * the commands server enable user to set proprties values 
         **/ 
        private CommandsServer(string ip,int port)
        {
            this.ip = ip;
            this.port = port;
        }
        #region
        private static CommandsServer instance = null;      // single instance of command server
        /** 
         *  Instance is static property which provides a mechanism to
         *  receive the instance of commands server
         **/
        public static CommandsServer Instance
        {
            get
            {
                /* if commands server is not exits, creates new server */
                ISettingsModel settingsModel = ApplicationSettingsModel.Instance;
                if (instance == null)
                    instance = new CommandsServer(settingsModel.FlightServerIP, settingsModel.FlightCommandPort);
                return instance;
            }
        }
        #endregion
        /**
        * ConnectToServer method connect to flightgear server in given ip and port.
        **/
        public override void connectToServer()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            client = new TcpClient();
            while (!client.Connected)
            {
                try { client.Connect(ep); }
                catch (Exception) { }
            }
            Console.WriteLine("You are connected");
        }
        /**
        *  closeConnection method close the connection to flightgear server.
        **/
        public override void closeConnection()
        {
            client.Close();
            instance = null;
        }

    }
}
