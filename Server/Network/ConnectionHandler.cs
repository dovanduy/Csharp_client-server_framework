using Shared.Library;
using Shared.Library.Connections;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Server.Network {

    public class ConnectionHandler {

        private TcpListener listener;


        public ConnectionHandler(TcpListener listener) {
            this.listener = listener;
        }

        public void ListenForConnectionRequests() {
            Console.WriteLine("Listening for connection requests...");

            while (listener != null) {
                if (listener.Pending()) {
                    Connection conn = new Connection(listener.AcceptTcpClient(), false);
                    ConnectionsRepository.AddConnection(conn, false);
                    conn.DataTransfered += DataProcessor.ProcessData;
                    conn.InitializeDataListener();
                    Console.WriteLine("New connection accepted.");
                }
            }
        }

        public void Reset() {
            listener = null;
        }

    }

}
