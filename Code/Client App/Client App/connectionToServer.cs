using System.Net.Sockets;

namespace Client_App
{
    public class connectionToServer
    {
        public TcpClient client;
        public NetworkStream networkStream;
        public int port = 1302; //standard
        public string IPAddress = "127.0.0.1"; //standard localhost
        public bool started = false;
    }
}