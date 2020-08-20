using System;
using System.Text;
using System.IO;
using System.Net.Sockets;
using ChatAppClasses;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Server_class server = new Server_class();
            Database DB = new Database();
            server.connectToDatabase(DB);
            server.run();
            
        }
    }
}
