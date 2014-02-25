using Server.DataAccess;
using Server.Game;
using Shared.Library;
using Shared.Library.Connections;
using Shared.Library.DataTransfering;
using Shared.Library.DataTransfering.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Network {

    public class DataProcessor {


        public static void ProcessData(Connection conn, DataTransfer transfer) {
            if (conn == null || transfer == null)
                return;

            if (transfer is AuthenticationRequest) {
                AuthenticationRequest authenticationRequest = (AuthenticationRequest)transfer;
                PlayerAccount player = new PlayerAccount(authenticationRequest.Username, authenticationRequest.Password);
                string authenticationResponseMessage = AccountFileHandler.ReadAccount(player);

                if (authenticationResponseMessage == null)
                    PlayerHandler.AddPlayer(player);

                conn.SendData(new AuthenticationResponse(authenticationResponseMessage));
            }
        }

    }

}
