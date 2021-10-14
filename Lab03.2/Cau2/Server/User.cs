using System.Net;

namespace Server
{
    public class User
    {
        public IPEndPoint IpEndpoint { get; private set; }
        public string Nickname { get; private set; }

        public User(string nickname, IPEndPoint endpoint)
        {
            IpEndpoint = endpoint;
            Nickname = nickname;
        }
    }
}
