using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cau2_Client
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
                    data = Encoding.ASCII.GetBytes("exit ");
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
            int sent;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            Socket server = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ipep);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Khong the ket noi den server");
                Console.WriteLine(e.ToString());
                return;
            }

            int recv = server.Receive(data);
            string stringData = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine(stringData);

            sent = SendData(server, Encoding.ASCII.GetBytes("Thong diep 1"));
            sent = SendData(server, Encoding.ASCII.GetBytes("Thong diep 2"));
            sent = SendData(server, Encoding.ASCII.GetBytes("Thong diep 3"));
            sent = SendData(server, Encoding.ASCII.GetBytes("Thong diep 4"));
            sent = SendData(server, Encoding.ASCII.GetBytes("Thong diep 5"));

            Console.WriteLine("Dong ket noi voi server...");
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

    }
}
