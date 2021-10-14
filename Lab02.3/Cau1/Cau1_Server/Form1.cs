using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1_Server
{
	public partial class frmServer : Form
	{
		ServerProgram serverProgram;

		public frmServer()
		{
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
			serverProgram = new ServerProgram();

			serverProgram.OnAddText += ServerProgram_OnAddText;
		}

		private void ServerProgram_OnAddText(object sender, AddTextEventArgs args)
		{
			txtMain.AppendText(args.Text);
			txtMain.AppendText(Environment.NewLine);
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			serverProgram.Start();
			btnStart.Enabled = false;
		}
	}
}
