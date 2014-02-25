
using Server.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server {

    class Program {


        static void Main(string[] args) {
            Console.WriteLine("Waiting for command input...");
            Console.WriteLine("Type /help for a list of commands.");
            CommandHandler.WaitForCommands();
        }

    }

}
