using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cau4_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[1024];
            string input, stringData;
            int recv;
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

            NetworkStream ns = new NetworkStream(server);

            if (ns.CanRead)
            {
                recv = ns.Read(data, 0, data.Length);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);
            }
            else
            {
                Console.WriteLine("Error: Can't read from this Socket");
                ns.Close();
                server.Close();
                return;
            }

            while (true)
            {
                input = Console.ReadLine();
                if (input == "exit")
                    break;
                if (ns.CanWrite)
                {
                    ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
                    ns.Flush();
                }
                recv = ns.Read(data, 0, data.Length);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);
            }
            Console.WriteLine("Dang ngat ket noi voi server...");
            ns.Close();
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
