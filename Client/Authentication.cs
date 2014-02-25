using Client.Library;
using Shared.Library;
using Shared.Library.Connections;
using Shared.Library.DataTransfering.Impl;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Client {

    public partial class Authentication : Form {

        private IPAddress ipAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });

        private const int port = 15000;


        public Authentication() {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e) {
            if (!ValidLoginInput())
                return;

            try {
                TcpClient client = new TcpClient();
                client.Connect(ipAddress, port);
                Connection conn = new Connection(client, true);

                conn.SendData(new AuthenticationRequest(GetUsername(), GetPassword()));

                AuthenticationResponse authentication = (AuthenticationResponse)conn.ReceiveData();

                if (authentication.Message == null) {
                    ConnectionsRepository.AddConnection(conn, true);
                    conn.DataTransfered += DataProcessor.ProcessData;
                    conn.InitializeDataListener();

                    this.Visible = false;
                    this.ShowInTaskbar = false;

                    GameForm game = new GameForm(conn);
                    conn.ShutdownRequest += ServerDown;
                    game.FormClosed += CloseClient;
                    game.Show();
                } else
                    noteLabel.Text = authentication.Message;

            } catch {
                noteLabel.Text = "No response from server.";
            }
        }

        private void CloseClient(object sender, FormClosedEventArgs e) {
            this.Visible = true;
            this.ShowInTaskbar = true;
        }

        private void ServerDown() {
            noteLabel.Text = "Server went down, try again in a few minutes.";
        }

        private bool ValidLoginInput() {
            if (GetUsername() == string.Empty) {
                noteLabel.Text = "No username given.";
                return false;
            }
            if (GetPassword() == string.Empty) {
                noteLabel.Text = "No password given.";
                return false;
            }
            if (GetUsername().Length < 6 || GetUsername().Length > 12) {
                noteLabel.Text = "Username has to contain 6-12 characters.";
                return false;
            }
            if (GetPassword().Length < 6 || GetPassword().Length > 12) {
                noteLabel.Text = "Username has to contain 6-12 characters.";
                return false;
            }
            Regex regex = new Regex(@"^\w+$");
            if (!regex.IsMatch(GetUsername())) {
                noteLabel.Text = "Your username contains invalid characters.";
                return false;
            }
            return true;
        }

        private string GetUsername() {
            return usernameTextBox.Text.Trim();
        }

        private string GetPassword() {
            return passwordTextBox.Text.Trim();
        }

    }

}
