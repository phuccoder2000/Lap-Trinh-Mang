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

namespace Server
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void frmServer_Load(object sender, EventArgs e)
        {

        }

        void StartServer()
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Any, 3000);
            UdpClient serverSocket = new UdpClient(serverEndpoint);

            IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Any, 0);

            lbMain.Items.Add("Dang cho client ket noi den...");

            byte[] data = new byte[2048];

            data = serverSocket.Receive(ref clientEndpoint);

            lbMain.Items.Add("Thong tin client ket noi: " + clientEndpoint);

            string dataStr = Encoding.ASCII.GetString(data, 0, data.Length);

            lbMain.Items.Add(clientEndpoint + ": " + dataStr);

            dataStr = "Xin chao client";
            data = Encoding.ASCII.GetBytes(dataStr);

            serverSocket.Send(data, data.Length, clientEndpoint);

            while (true)
            {
                data = serverSocket.Receive(ref clientEndpoint);
                dataStr = Encoding.ASCII.GetString(data, 0, data.Length);
                lbMain.Items.Add(clientEndpoint + ": " + dataStr);

                serverSocket.Send(data, data.Length, clientEndpoint);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Thread startServerThread = new Thread(new ThreadStart(StartServer));
            startServerThread.Start();

            btnStart.Enabled = false;
        }
    }
}
