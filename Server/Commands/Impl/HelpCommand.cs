using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands.Impl {

    public class HelpCommand : Command {


        public void ProcessCommand() {
            Console.WriteLine("~~~ Commands list ~~~");
            Console.WriteLine("/help");
            Console.WriteLine("/launch");
            Console.WriteLine("/shutdown");
        }

    }

}
