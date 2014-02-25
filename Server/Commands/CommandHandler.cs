using Server.Commands.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands {

    public class CommandHandler {


        public static void WaitForCommands() {
            while (true) {
                string command = Console.ReadLine();
                if (command != string.Empty) {
                    if (command.StartsWith("/"))
                        ReadCommand(command.Substring(1));
                }
            }
        }

        private static void ReadCommand(string command) {
            switch (command.ToLower()) {

                case "help":
                    ParseCommand(new HelpCommand());
                    break;

                case "shutdown":
                    ParseCommand(new ShutdownCommand());
                    break;

                case "launch":
                    ParseCommand(new LaunchCommand());
                    break;

            }
        }

        private static void ParseCommand(Command command) {
            if (command != null)
                command.ProcessCommand();
        }

    }
}
