﻿using System;
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
            User newUser = new User("Ultimul", "parolaUltimul");
            User newUser1 = new User("Ultimul", "parolaUltimul");
            //DB.AddUser(newUser);
            server.connectToDatabase(DB);
            //newUser.sendMessage("Am ajuns", Server.serverDatabase.GetUserById(1));
            //newUser.getMessagesWith(Server.serverDatabase.GetUserById(1));
            //newUser.deleteMessage("Voi fi stersa");
            //newUser.deleteConversation(Server.serverDatabase.GetUserById(1).username);
            //newUser1.Login();
            server.run();
            
        }
    }
}
