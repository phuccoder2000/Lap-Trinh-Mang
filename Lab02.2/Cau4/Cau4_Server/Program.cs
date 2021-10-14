using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cau4_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Số byte thực sự nhận được dùng hàm Receive()
            int byteReceive;
            //buffer để nhận và gởi dữ liệu
            byte[] buff = new byte[1024];
            //EndPoint cục bộ
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5000);
            //Server Socket
            Socket server = new Socket(AddressFamily.InterNetwork,
           SocketType.Stream, ProtocolType.Tcp);
            //Kết nối server với 1 EndPoint
            server.Bind(ipep);
            //Server lắng nghe tối đa 10 kết nối
            server.Listen(10);
            Console.WriteLine("Dang cho Client ket noi den...");
            //Hàm Accept() sẽ block server lại cho đến khi có Client kết nối đến
            Socket client = server.Accept();
            //Client EndPoint
            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("Da ket noi voi Client {0} tai port {1}",
           clientep.Address, clientep.Port);
            string welcome = "Hello Client";
            //Chuyển chuỗi thành mảng các byte
            buff = Encoding.ASCII.GetBytes(welcome);
            //Gởi câu chào cho Client
            client.Send(buff, buff.Length, SocketFlags.None);
            while (true)
            {
                //Reset lại buffer
                buff = new byte[1024];
                //Lấy số byte thực sự nhận được
                byteReceive = client.Receive(buff);
                //Nếu Client ngắt kết nối thì thoát khỏi vòng lặp
                if (byteReceive == 0)
                    break;
                Console.WriteLine(Encoding.ASCII.GetString(buff, 0, byteReceive));
                //Sau khi nhận dữ liệu xong, gởi lại cho Client
                client.Send(buff, byteReceive, SocketFlags.None);
            }
            Console.WriteLine("Da dong ket noi voi Client: {0}", clientep.Address);
            //Đóng kết nối
            client.Close();
            server.Close();
        }
    }
}
