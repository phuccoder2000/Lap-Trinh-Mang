using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cau3_Client
{
    class Program
    {
        private static int SendVarData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = s.Send(datasize);
            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }

        private static byte[] ReceiveVarData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];
            recv = s.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];
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
                Console.WriteLine("Khong the ket noi voi server");
                Console.WriteLine(e.ToString());
                return;
            }

            data = ReceiveVarData(server);

            string stringData = Encoding.ASCII.GetString(data);
            Console.WriteLine(stringData);

            string message1 = "Day la thong diep dau tien";
            string message2 = "Thong diep ngan";
            string message3 = "Thong diep nay dai hon cac thong diep khac";
            string message4 = "a";
            string message5 = "Thong diep cuoi cung";

            sent = SendVarData(server, Encoding.ASCII.GetBytes(message1));
            sent = SendVarData(server, Encoding.ASCII.GetBytes(message2));
            sent = SendVarData(server, Encoding.ASCII.GetBytes(message3));
            sent = SendVarData(server, Encoding.ASCII.GetBytes(message4));
            sent = SendVarData(server, Encoding.ASCII.GetBytes(message5));

            Console.WriteLine("Dang ngat ket noi voi server...");
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
