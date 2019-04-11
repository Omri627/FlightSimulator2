using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.Model
{
    class InfoServerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private int port;
        private Server server;
        InfoServerCommand(int port)  {
            this.port = port;
            server = new Server(port);
        }
        public bool CanExecute(object parameter)  {
            return true;
        }

        public void Execute(object parameter)  {
            server.connectToServer();
            string message = server.read();
            server.closeConnection();
        }
    }
}
