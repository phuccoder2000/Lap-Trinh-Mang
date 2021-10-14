using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class frmServer : Form
    {
        UdpClient serverSocket;
        IPEndPoint clientEndpoint;

        List<User> users = new List<User>();
        List<clientForm> remoteScreens = new List<clientForm>();

        public frmServer()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            lbClients.DoubleClick += LbClients_DoubleClick;
        }

        private void LbClients_DoubleClick(object sender, EventArgs e)
        {
            if (lbClients.SelectedItem == null)
                return;

            string userNickname = lbClients.SelectedItem.ToString();
            User user = users.Find(u => u.Nickname.Equals(userNickname));

            clientForm frm = new clientForm(user);
            frm.OnSendButtonPressed += OnSendButtonPressedHandler;
            frm.OnClientFormClosing += OnClientFormClosingHandler;

            frm.Show();

            remoteScreens.Add(frm);
        }

        void OnSendButtonPressedHandler(string str, IPEndPoint remoteEndpoint)
        {
            byte[] data = Encoding.ASCII.GetBytes(str);
            serverSocket.Send(data, data.Length, remoteEndpoint);

            lbClientMessages.Items.Add("Admin to " + remoteEndpoint + ": " + str);
        }

        void OnClientFormClosingHandler(clientForm frm)
        {
            remoteScreens.Remove(frm);
        }

        void StartServer()
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 3000);
            serverSocket = new UdpClient(serverEndpoint);

            clientEndpoint = new IPEndPoint(IPAddress.Any, 0);

            lbClientMessages.Items.Add("Server khoi dong tai dia chi: " + serverEndpoint);

            byte[] buffer;

            string dataStr;

            while (true)
            {
                try
                {
                    buffer = serverSocket.Receive(ref clientEndpoint);
                }
                catch
                {
                    break;
                }

                dataStr = Encoding.ASCII.GetString(buffer, 0, buffer.Length);

                if (IsNewClientConnection(clientEndpoint))
                {
                    string userNickname = dataStr;
                    lbClients.Items.Add(userNickname);
                    users.Add(new User(userNickname, clientEndpoint));
                    lbClientMessages.Items.Add(clientEndpoint + ": Vua ket noi vao he thong.");

                    dataStr = "Xin chao client";
                    buffer = Encoding.ASCII.GetBytes(dataStr);

                    serverSocket.Send(buffer, buffer.Length, clientEndpoint);
                }
                
                if (dataStr.Equals("client_exit"))
                {
                    lbClientMessages.Items.Add(clientEndpoint + ": Vua ngat ket noi.");

                    foreach (clientForm form in remoteScreens)
                    {
                        if (clientEndpoint.ToString().Equals(form.RemoteEndpoint.ToString()))
                        {
                            form.Close();
                            break;
                        }
                    }

                    User user = users.Find(u => u.IpEndpoint.ToString().Equals(clientEndpoint.ToString()));

                    if (user != null)
                    {
                        users.Remove(user);

                        foreach (var item in lbClients.Items)
                        {
                            if (item.ToString().Equals(user.Nickname))
                            {
                                lbClients.Items.Remove(item);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    lbClientMessages.Items.Add(clientEndpoint + ": " + dataStr);
                }

                foreach (clientForm form in remoteScreens)
                {
                    if (clientEndpoint.ToString().Equals(form.RemoteEndpoint.ToString()))
                    {
                        form.AppendMessage(dataStr);
                        break;
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread startServerThread = new Thread(new ThreadStart(StartServer));
            startServerThread.IsBackground = true;
            startServerThread.Start();

            btnStart.Enabled = false;
        }

        bool IsNewClientConnection(IPEndPoint clientEndpoint)
        {
            if (lbClients.Items.Count == 0) return true;

            foreach (User user in users)
            {
                if (user.IpEndpoint.ToString().Equals(clientEndpoint.ToString()))
                    return false;
            }

            return true;
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            btnStart.PerformClick();
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverSocket.Close();
        }
    }
}
