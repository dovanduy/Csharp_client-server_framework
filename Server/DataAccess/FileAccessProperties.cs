using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server.DataAccess {

    public class FileAccessProperties {

        public static BinaryFormatter Formatter = new BinaryFormatter();

        public const string PlayerAccountSaveLocation = "./player-accounts/";

    }

}
