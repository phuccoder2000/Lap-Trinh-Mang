using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1_Client
{
	public partial class frmClient : Form
	{
		ClientProgram clientProgram;

		public frmClient()
		{
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
			clientProgram = new ClientProgram();

			clientProgram.OnAddText += ClientProgram_OnAddText;
		}

		private void ClientProgram_OnAddText(object sender, AddTextEventArgs args)
		{
			txtMain.AppendText(args.Text);
			txtMain.AppendText(Environment.NewLine);
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			btnConnect.Enabled = false;
			clientProgram.Connect();
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			string message = txtInput.Text;
			clientProgram.SendData(message);
		}
	}
}
