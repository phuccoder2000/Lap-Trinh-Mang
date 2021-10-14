using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01_Bai03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            IPAddress ip = GetLocalIPAddress();
            IPAddress subnetMask = GetSubnetMask(ip);
            IPAddress defaultGateway = GetDefaultGateway();

            txtIPv4.Text = ip.ToString();
            txtSubnetMask.Text = subnetMask.ToString();
            txtDefaultGateway.Text = defaultGateway.ToString();
        }

        string GetHostInfo(string host)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(host);

                StringBuilder result = new StringBuilder();

                foreach (IPAddress iPAddress in hostInfo.AddressList)
                {
                    result.AppendLine(iPAddress.ToString());
                }

                return result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Co loi xay ra trong qua trinh phan giai ten mien");
                return null;
            }
        }

        public static IPAddress GetDefaultGateway()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(n => n.OperationalStatus == OperationalStatus.Up)
                .Where(n => n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .SelectMany(n => n.GetIPProperties()?.GatewayAddresses)
                .Select(g => g?.Address)
                .Where(a => a != null)
                // .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                // .Where(a => Array.FindIndex(a.GetAddressBytes(), b => b != 0) >= 0)
                .FirstOrDefault();
        }

        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static IPAddress GetSubnetMask(IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Can't find subnetmask for IP address '{0}'", address));
        }

        private void btnPhanGiai_Click(object sender, EventArgs e)
        {
            string tenMien = txtTenMien.Text;
            string IpList = GetHostInfo(tenMien);
            if(!string.IsNullOrWhiteSpace(IpList))
            {
                txtDanhSachIP.Text = IpList;
            }
        }
    }
}
