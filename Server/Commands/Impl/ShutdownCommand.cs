using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands.Impl {

    public class ShutdownCommand : Command {


        public void ProcessCommand() {
            Console.WriteLine("Shutting down the server...");
            NetworkServer.Shutdown();
        }

    }

}
