using Shared.Library.DataTransfering;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Shared.Library.Connections {

    public class Connection {

        private TcpClient client;

        private bool clientSidedConnection;

        private BinaryFormatter formatter = new BinaryFormatter();

        public event Action<Connection, DataTransfer> DataTransfered;

        public event Action ShutdownRequest;


        public Connection(TcpClient client, bool clientSidedConnection) {
            this.client = client;
            this.clientSidedConnection = clientSidedConnection;
        }

        public void InitializeDataListener() {
            Thread thread = new Thread(ListenForIncomingData);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Destruct() {
            if (clientSidedConnection) {
                ShutdownRequest();
            }
            client.Close();
        }

        private void ListenForIncomingData() {
            while (client != null && client.Connected) {
                try {
                    DataTransfered(this, ReceiveData());
                } catch (IOException ioe) {
                    Destruct();
                    Console.WriteLine(ioe);
                } catch (SerializationException se) {
                    Destruct();
                   Console.WriteLine(se);
                }
            }
        }

        public void SendData(DataTransfer transfer) {
            if (client.Connected)
                formatter.Serialize(client.GetStream(), transfer);
        }

        public DataTransfer ReceiveData() {
            if (client.Connected) {
                object obj = formatter.Deserialize(client.GetStream());
                if (obj != null)
                    return (DataTransfer)obj;
                else
                    Destruct();
            }
            return null;
        }

        public TcpClient GetClient() {
            return client;
        }

    }

}
