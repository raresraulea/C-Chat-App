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
            //TcpListener listener = new TcpListener(System.Net.IPAddress.Any,1302);
            //listener.Start(); mutat in SV

            Server server = new Server();
            Database DB = new Database();

            User Adi = DB.GetUserById(3);
            Console.WriteLine(Adi.username + " " + Adi.password);
            server.start();

            User newUser = new User("UserNou", "parolaNoua");
            User newUser1 = new User("UserNou1", "parolaNoua1");

            //DB.AddUser(user12);
            //DB.EditPassword(user12, "nouaParolaAluiAdi");
            //DB.DeleteUser(newUser1);


        }
    }
}
