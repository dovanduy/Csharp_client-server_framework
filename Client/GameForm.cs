using Shared.Library;
using Shared.Library.Connections;
using System.Windows.Forms;

namespace Client {

    public partial class GameForm : Form {

        private Connection conn;


        public GameForm(Connection conn) {
            InitializeComponent();
            this.conn = conn;
            conn.ShutdownRequest += CloseGame;
        }

        private void CloseGame() {
            this.Close();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e) {
            ConnectionsRepository.RemoveConnection(conn);
        }

    }

}
