using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands.Impl {

    public class LaunchCommand : Command {


        public void ProcessCommand() {
            Console.WriteLine("Launching the server...");
            NetworkServer.Launch();
        }

    }

}
