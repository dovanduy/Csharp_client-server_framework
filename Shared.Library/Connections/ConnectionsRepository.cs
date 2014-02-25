using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Library.Connections {

    public class ConnectionsRepository {

        private static Dictionary<Connection, bool> connections = new Dictionary<Connection, bool>();


        public static void AddConnection(Connection connection, bool client) {
            connections.Add(connection, client);
        }

        public static void RemoveConnection(Connection connection) {
            connections.Remove(connection);
        }

        public static void Reset() {
            foreach (KeyValuePair<Connection, bool> kvp in connections)
                kvp.Key.Destruct();
        }

    }

}
