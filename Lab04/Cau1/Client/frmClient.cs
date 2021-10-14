using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class frmClient : Form
    {
        ClientProgram client;
        public frmClient()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new ClientProgram();
            client.SetTextFunction += Client_SetTextFunction;

            client.Connect();
            btnSend.Enabled = true;
        }

        private void Client_SetTextFunction(string Text)
        {
            lsbMain.Items.Add(Text);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.SendToServer(txtInput.Text);
            txtInput.Text = "";
        }
    }
}
