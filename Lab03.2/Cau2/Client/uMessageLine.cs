using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class uMessageLine : UserControl
    {
        public uMessageLine()
        {
            InitializeComponent();
            txtTime.BorderStyle = BorderStyle.None;
            txtMessageContent.BorderStyle = BorderStyle.None;
            txtUsername.BorderStyle = BorderStyle.None;
        }

        public void SetMessageContent(string message, string nickane = "Admin", bool isSender = true)
        {
            txtMessageContent.Text = message;      
            txtTime.Text = DateTime.Now.ToString("hh:MM:ss tt");
            txtUsername.Text = nickane;

            int lineheight = 3;
            int a = message.Length / 60;

            if (a > 0)
                this.Height += this.Height + a * lineheight;

            if (isSender)
            {
                txtMessageContent.TextAlign = HorizontalAlignment.Right;
                txtTime.TextAlign = HorizontalAlignment.Right;
                txtUsername.TextAlign = HorizontalAlignment.Right;
                txtUsername.ForeColor = Color.DarkOrchid;
            }
            else
            {
                txtMessageContent.TextAlign = HorizontalAlignment.Left;
                txtTime.TextAlign = HorizontalAlignment.Left;
                txtUsername.TextAlign = HorizontalAlignment.Left;
                txtUsername.ForeColor = Color.DarkOrange;
            }
        }

        public void SetWidth(int width)
        {
            this.Width = width;
        }
    }
}
