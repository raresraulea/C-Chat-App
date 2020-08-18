using System;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            Database DB = new Database();

            server.connectToDatabase(DB);
            server.run();

        }
    }
}
