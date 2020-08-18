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
            //newUser.sendMessage("Am ajuns", Server.serverDatabase.GetUserById(1));
            //newUser.deleteMessage("Voi fi stersa");
            //newUser.deleteConversation(Server.serverDatabase.GetUserById(1).username);
            newUser.Login();
            server.run();
            
        }
    }
}
