using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            btnStart.PerformClick();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ServerProgram server = new ServerProgram();
            server.SetTextFunction += Server_SetTextFunction;

            server.StartServer();
            btnStart.Enabled = false;
        }

        private void Server_SetTextFunction(string Text)
        {
            lsbMain.Items.Add(Text);
        }
    }
}
