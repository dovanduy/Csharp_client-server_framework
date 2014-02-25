using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Library.DataTransfering.Impl {
    [Serializable]
    public class AuthenticationRequest : DataTransfer {

        public string Username {
            get;
            private set;
        }

        public string Password {
            get;
            private set;
        }


        public AuthenticationRequest(string username, string password) {
            this.Username = username;
            this.Password = password;
        }

    }

}
