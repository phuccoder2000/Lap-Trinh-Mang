using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cau1_Client
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

            serverSocket.Send(Encoding.ASCII.GetBytes("Thong diep 1"));
            serverSocket.Send(Encoding.ASCII.GetBytes("Thong diep 2"));
            serverSocket.Send(Encoding.ASCII.GetBytes("Thong diep 3"));
            serverSocket.Send(Encoding.ASCII.GetBytes("Thong diep 4"));
            serverSocket.Send(Encoding.ASCII.GetBytes("Thong diep 5"));
            serverSocket.Send(Encoding.ASCII.GetBytes("Thong diep 6"));
            serverSocket.Send(Encoding.ASCII.GetBytes("Thong diep 7"));
            serverSocket.Send(Encoding.ASCII.GetBytes("Thong diep 8"));
            serverSocket.Send(Encoding.ASCII.GetBytes("Thong diep 9"));

            Console.ReadKey();

            serverSocket.Close();
        }
    }
}
