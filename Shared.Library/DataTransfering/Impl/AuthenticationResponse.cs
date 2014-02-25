using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Library.DataTransfering.Impl {
    [Serializable]
    public class AuthenticationResponse : DataTransfer {

        public string Message {
            get;
            private set;
        }


        public AuthenticationResponse(string message) {
            this.Message = message;
        }

    }

}
