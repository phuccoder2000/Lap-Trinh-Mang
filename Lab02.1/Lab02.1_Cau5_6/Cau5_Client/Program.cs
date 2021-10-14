using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cau5_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 5000);

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Dang ket noi toi server...");

            try
            {
                serverSocket.Connect(serverEndpoint);
            }
            catch (SocketException ex)
            {
                Console.WriteLine("Co loi trong qua trinh ket noi tu server");
                Console.WriteLine("Thong bao loi: " + ex.Message);
                Console.ReadKey();
                return;
            }

            if (!serverSocket.Connected)
            {
                Console.WriteLine("Co loi trong qua trinh ket noi tu server");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Ket noi thanh cong toi server...");

            while (true)
            {

                Console.Write("Enter message (press q to quit): ");
                string str = Console.ReadLine();

                if(str.Equals("q"))
                {
                    break;
                }

                byte[] buffInput = Encoding.ASCII.GetBytes(str);

                serverSocket.Send(buffInput, 0, buffInput.Length, SocketFlags.None);

                byte[] buffResult = new byte[1024];
                int byteReceive = serverSocket.Receive(buffResult, 0, buffResult.Length, SocketFlags.None);

                string strResult = Encoding.ASCII.GetString(buffResult, 0, byteReceive);

                Console.WriteLine("Ket qua tra ve tu server: " + strResult);
            }

            Console.ReadKey();

            serverSocket.Close();
        }
    }
}
