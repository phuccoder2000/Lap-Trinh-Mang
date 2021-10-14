using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Client
{
    public partial class frmClient : Form
    {
        UdpClient serverSocket;
        string userNickname;

        public frmClient(string userNickname)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            btnSend.Enabled = false;

            this.Text = "Xin chao " + userNickname;
            this.userNickname = userNickname;

            lbMain.AutoScroll = false;
            lbMain.VerticalScroll.Visible = true;
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            btnConnect.PerformClick();
        }

        void ConnectToServer()
        {
            serverSocket = new UdpClient("127.0.0.1", 3000);
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 3000);

            string str = userNickname;
            byte[] data = Encoding.ASCII.GetBytes(str);

            serverSocket.Send(data, data.Length);

            data = serverSocket.Receive(ref serverEndpoint);

            str = Encoding.ASCII.GetString(data, 0, data.Length);

            uMessageLine row = new uMessageLine();
            row.SetWidth(this.Width - 65);
            row.SetMessageContent(str, "Admin", false);

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lbMain.Controls.Add(row);
                });
            }
            else
            {
                lbMain.Controls.Add(row);
            }

            Thread listenToServer = new Thread(new ThreadStart(ListenToServer));
            listenToServer.IsBackground = true;
            listenToServer.Start();
        }

        void ListenToServer()
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                byte[] data = serverSocket.Receive(ref serverEndpoint);
                string str = Encoding.ASCII.GetString(data, 0, data.Length);

                uMessageLine row = new uMessageLine();
                row.SetWidth(this.Width - 65);
                row.SetMessageContent(str, "Admin", false);

                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        lbMain.Controls.Add(row);
                        if (!lbMain.AutoScroll)
                        {
                            if (GetContentHeight() > 170)
                                lbMain.AutoScroll = true;
                        }
                        lbMain.ScrollControlIntoView(row);
                    });
                }
                else
                {
                    lbMain.Controls.Add(row);
                    if (!lbMain.AutoScroll)
                    {
                        if (GetContentHeight() > 170)
                            lbMain.AutoScroll = true;
                    }
                    lbMain.ScrollControlIntoView(row);
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Thread connectToServerThread = new Thread(new ThreadStart(ConnectToServer));
            connectToServerThread.IsBackground = true;
            connectToServerThread.Start();

            btnConnect.Enabled = false;
            btnSend.Enabled = true;
        }

        int GetContentHeight()
        {
            int height = 0;

            foreach (Client.uMessageLine item in lbMain.Controls)
            {
                height += item.Height;
            }

            return height;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtInput.Text;
            byte[] data = Encoding.ASCII.GetBytes(message);
            serverSocket.Send(data, data.Length);

            uMessageLine row = new uMessageLine();
            row.SetWidth(this.Width - 65);
            row.SetMessageContent(txtInput.Text, userNickname);

            lbMain.Controls.Add(row);

            txtInput.Text = "";

            if (!lbMain.AutoScroll)
            {
                if (GetContentHeight() > 170)
                    lbMain.AutoScroll = true;
            }

            lbMain.ScrollControlIntoView(row);
        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            string message = "client_exit";
            byte[] data = Encoding.ASCII.GetBytes(message);
            serverSocket.Send(data, data.Length);
        }
    }
}
