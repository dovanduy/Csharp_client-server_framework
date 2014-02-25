using Server.Game;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataAccess {

    public class AccountFileHandler {


        public static void SaveAccount(PlayerAccount player) {
            using (Stream stream = File.Open(FileAccessProperties.PlayerAccountSaveLocation + player.Username + ".dat", FileMode.OpenOrCreate))
                FileAccessProperties.Formatter.Serialize(stream, player);
        }

        public static string ReadAccount(PlayerAccount player) {
            PlayerAccount loadedAccount = null;
            string filePath = FileAccessProperties.PlayerAccountSaveLocation + player.Username + ".dat";

            if (!File.Exists(filePath)) {
                SaveAccount(player);
                return null;
            }

            using (Stream stream = File.Open(FileAccessProperties.PlayerAccountSaveLocation + player.Username + ".dat", FileMode.Open))
                   loadedAccount = (PlayerAccount)FileAccessProperties.Formatter.Deserialize(stream);

             if (loadedAccount.Password != player.Password)
                return "Wrong password.";
            else {
                player = loadedAccount;
                return null;
            }
        }

    }

}
