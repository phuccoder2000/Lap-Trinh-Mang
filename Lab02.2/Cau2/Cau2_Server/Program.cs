using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cau2_Server
{
    class Program
    {
        private static int SendData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }
        private static byte[] ReceiveData(Socket s, int size)
        {
            int total = 0;
            int dataleft = size;
            byte[] data = new byte[size];
            int recv;
            while (total < size)
            {
                recv = s.Receive(data, total, dataleft, 0);
                if (recv == 0)
                {
                    data = Encoding.ASCII.GetBytes("exit");
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            return data;
        }

        static void Main(string[] args)
        {
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5000);
            Socket newsock = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

            newsock.Bind(ipep);
            newsock.Listen(10);

            Console.WriteLine("Dang cho Client ket noi den...");

            Socket client = newsock.Accept();
            IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;

            Console.WriteLine("Da ket noi voi Client {0} tai port {1}",
            newclient.Address, newclient.Port);

            string welcome = "Hello Client";
            data = Encoding.ASCII.GetBytes(welcome);
            int sent = SendData(client, data);

            for (int i = 0; i < 5; i++)
            {
                data = ReceiveData(client, 12);
                Console.WriteLine(Encoding.ASCII.GetString(data));
            }

            Console.WriteLine("Da ngat ket noi voi Client {0}", newclient.Address);
            client.Close();
            newsock.Close();
        }
    }
}
