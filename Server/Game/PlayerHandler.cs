using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Game {

    public class PlayerHandler {

        private static List<PlayerAccount> players = new List<PlayerAccount>();


        public static void AddPlayer(PlayerAccount player) {
            players.Add(player);
        }

        public static void RemovePlayer(PlayerAccount player) {
            players.Remove(player);
        }

        public static List<PlayerAccount> GetPlayers() {
            return players;
        }

    }

}
