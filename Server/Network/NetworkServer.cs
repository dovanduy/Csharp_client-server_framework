using Server.DataAccess;
using Server.Game;
using Shared.Library;
using Shared.Library.Connections;
using Shared.Library.DataTransfering.Impl;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server.Network {

    public class NetworkServer {

        private static bool online;

        private static TcpListener listener = new TcpListener(IPAddress.Any, 15000);

        private static Thread thread;

        private static ConnectionHandler connectionHandler;


        public static void Launch() {
            listener.Start();

            connectionHandler = new ConnectionHandler(listener);

            thread = new Thread(connectionHandler.ListenForConnectionRequests);
            thread.IsBackground = true;
            thread.Start();

            online = true;
        }

        public static void Shutdown() {
            if (online) {
                connectionHandler.Reset();
                ConnectionsRepository.Reset();

                foreach (PlayerAccount account in PlayerHandler.GetPlayers())
                    AccountFileHandler.SaveAccount(account);

                listener.Stop();
                thread.Abort();

                Console.WriteLine("Server has shut down.");
            } else
                Console.WriteLine("Failed since the server isn't online.");
        }

    }

}
