using System.Net.Sockets;

namespace Client_App
{
    internal class connectionToServer
    {
        public TcpClient client;
        public NetworkStream networkStream;
    }
}