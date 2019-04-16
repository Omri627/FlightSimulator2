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
using System.ComponentModel;

namespace FlightSimulator.Model
{
    class InfoServer : Server, INotifyPropertyChanged {
        private bool isListening;           // isListening indicate if the server already listening 
        private int port;                   // port of the connection between server and this application 
        private TcpListener listener;       // tcp listener
        private SymbolTable symbolTable;    // symboltable object contains data of the proprties of flight

        public event PropertyChangedEventHandler PropertyChanged;

        /**
* the constructor creates new info server.
* the class contins methods to handle server: connect, disconnect, read and send messages
* the info server received data from flightgear server
**/
        public InfoServer(int port) {
            this.port = port;
            symbolTable = SymbolTable.Instance;
            stop = false;
            isListening = false;
        }
        /**
         * ConnectToServer method connect to flightgear server in given ip and port.
         **/
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
        /**
        *  closeConnection method close the connection to flightgear server.
        **/
        public override void closeConnection()  {
            Stop = true;
            client.Close();
            listener.Stop();
            client = null;
            symbolTable.NotifyCloseConnection();
        }
        /**
         * ReadDataContinously methods continiously reads data from server
         * and update data set symbol table which contains all the properties values from server
         **/
        public void ReadDataContinously()
        {
            string data;                            // data received from server
            while (Stop == false)
            {
                data = Read();                      // read data
                symbolTable.UpdateData(data);       // update symbol-table
            }
        }
    }
}
