using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Game {
    [Serializable]
    public class PlayerAccount {

        public string Username {
            get;
            private set;
        }

        public string Password {
            get;
            set;
        }


        public PlayerAccount(string username, string password) {
            this.Username = username;
            this.Password = password;
        }

    }

}
