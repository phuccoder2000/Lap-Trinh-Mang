using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class clientForm : Form
    {
        private event Action<string, IPEndPoint> _onSendButtonPressed;
        public event Action<string, IPEndPoint> OnSendButtonPressed
        {
            add
            {
                _onSendButtonPressed += value;
            }
            remove
            {
                _onSendButtonPressed -= value;
            }
        }

        private event Action<clientForm> _onClientFormClosing;
        public event Action<clientForm> OnClientFormClosing
        {
            add
            {
                _onClientFormClosing += value;
            }
            remove
            {
                _onClientFormClosing -= value;
            }
        }

        public IPEndPoint RemoteEndpoint { get; private set; }
        public string UserNickname { get; private set; }

        public clientForm(User user)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            RemoteEndpoint = user.IpEndpoint;
            UserNickname = user.Nickname;

            lbMain.AutoScroll = false;
            lbMain.VerticalScroll.Visible = true;

            txtClientIP.Text = "Chat with: " + user.Nickname;
        }

        private void clientForm_Load(object sender, EventArgs e)
        {

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
            Client.uMessageLine row = new Client.uMessageLine();
            row.SetWidth(this.Width - 65);
            row.SetMessageContent(txtInput.Text);

            lbMain.Controls.Add(row);

            _onSendButtonPressed?.Invoke(txtInput.Text, RemoteEndpoint);

            txtInput.Text = "";

            if (!lbMain.AutoScroll)
            {
                if (GetContentHeight() > 170)
                    lbMain.AutoScroll = true;
            }

            lbMain.ScrollControlIntoView(row);
        }

        public void AppendMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    Client.uMessageLine row = new Client.uMessageLine();
                    row.SetWidth(this.Width - 65);
                    row.SetMessageContent(message, UserNickname, false);

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
                Client.uMessageLine row = new Client.uMessageLine();
                row.SetWidth(this.Width - 65);
                row.SetMessageContent(message, UserNickname, false);

                lbMain.Controls.Add(row);
                if (!lbMain.AutoScroll)
                {
                    if (GetContentHeight() > 170)
                        lbMain.AutoScroll = true;
                }
                lbMain.ScrollControlIntoView(row);
            }
        }

        private void clientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _onClientFormClosing?.Invoke(this);
        }
    }
}
