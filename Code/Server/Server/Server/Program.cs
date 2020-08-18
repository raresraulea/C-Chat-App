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
            User newUser = new User("Ultimul", "parolaUltimul");
            //DB.AddUser(newUser);
            server.connectToDatabase(DB);
            newUser.sendMessage("Hello World!", Server.serverDatabase.GetUserById(1));

            //newUser.Login("1234acasa", newUser.password);
            server.run();
            
        }
    }
}
