using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FlightSimulator.Model
{
    class AutoPilotModel
    {
        private CommandsServer server;          // commands flight server
        /**
         * AutoPilotModel creates auto-pilot model instance
         * the model responsible for auto-pilot logics and contains methods which performs
         * complex calculations and operations
         **/ 
        public AutoPilotModel()
        {
            server = CommandsServer.Instance;
        }
        /**
         * GetCommands method gets a code,
         * and returns a list of commands given by the code
         **/
        public List<string> GetCommands(string code)
        {
            return code.Split('\n').ToList();
        }
        /**
         * ExecuteCode method gets list of commands,
         * and executes the command one by one.
         **/
        public void ExecuteCode(string code)
        {            
            if (server == null || code == null || code == string.Empty)
                return;
            List<string> commands = GetCommands(code);
            foreach (string cmd in commands) {
                server.Write(cmd + "\r\n");
                Thread.Sleep(2000);                     // delay for 2 seconds
            }

        }
    }
}
