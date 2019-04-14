using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class AutoPilotModel
    {
        private CommandsServer server;
        public AutoPilotModel()
        {
            server = CommandsServer.Instance;
        }
        public List<string> GetCommands(string code)
        {
            return code.Split('\n').ToList();
        }
        public void ExecuteCode(string code)
        {
            server = CommandsServer.Instance;
            if (server == null)
                return;
            List<string> commands = GetCommands(code);
            foreach (string cmd in commands) {
                server.write(cmd);
            }
        }
    }
}
