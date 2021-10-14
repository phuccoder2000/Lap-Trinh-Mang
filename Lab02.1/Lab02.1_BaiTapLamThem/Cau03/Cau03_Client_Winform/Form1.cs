using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau03_Client_Winform
{
    public partial class Calculator : Form
    {

        string calculation = "";
        IPEndPoint serverEndpoint;
        Socket serverSocket;

        public Calculator()
        {
            InitializeComponent();

            serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Connect(serverEndpoint);
            }
            catch
            {
                MessageBox.Show("Co loi trong qua trinh ket noi den server");
            }

            if (!serverSocket.Connected)
            {
                MessageBox.Show("Co loi trong qua trinh ket noi den server");                
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            calculation += "0";
            txtResult.Text = calculation;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            calculation += "1";
            txtResult.Text = calculation;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            calculation += "2";
            txtResult.Text = calculation;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            calculation += "3";
            txtResult.Text = calculation;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            calculation += "4";
            txtResult.Text = calculation;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            calculation += "5";
            txtResult.Text = calculation;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            calculation += "6";
            txtResult.Text = calculation;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            calculation += "7";
            txtResult.Text = calculation;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            calculation += "8";
            txtResult.Text = calculation;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            calculation += "9";
            txtResult.Text = calculation;
        }

        private void btnOperatorAdd_Click(object sender, EventArgs e)
        {
            calculation += "+";
            txtResult.Text = calculation;
        }

        private void btnOperatorMinus_Click(object sender, EventArgs e)
        {
            calculation += "-";
            txtResult.Text = calculation;
        }

        private void btnOperatorMultiply_Click(object sender, EventArgs e)
        {
            calculation += "x";
            txtResult.Text = calculation;
        }

        private void btnOperatorDivision_Click(object sender, EventArgs e)
        {
            calculation += "/";
            txtResult.Text = calculation;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
            calculation = "";
        }

        private void btnOperatorResult_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] buffInput = Encoding.ASCII.GetBytes(calculation);

                serverSocket.Send(buffInput, 0, buffInput.Length, SocketFlags.None);

                byte[] buffResult = new byte[1024];
                int byteReceive = serverSocket.Receive(buffResult, 0, buffResult.Length, SocketFlags.None);

                string strResult = Encoding.ASCII.GetString(buffResult, 0, byteReceive);

                calculation += "=" + strResult;
                txtResult.Text = calculation;
            }
            catch
            {
                MessageBox.Show("Co loi trong qua trinh tinh toan tren server");
            }
        }

    }
}
