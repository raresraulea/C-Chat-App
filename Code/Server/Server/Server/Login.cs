using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{

    class Login
    {
        private static Login instance = null;

        private Login()
        {
        }
        public static Login Instance
        {
            get
            {
                if (instance == null)
                    instance = new Login();
                return instance;
            }
        }

        public void verifyLoginData(User user)
        {
            if (Server.serverDatabase.checkCredentials(user.username, user.password))
            {
                LoginToServer(user);
            }
            else
            {
                SignUp(user);
                LoginToServer(user);
            }
        }

        private void SignUp(User user)
        {
            if(Server.serverDatabase.usernameAvailable(user.username))
            {
                Server.serverDatabase.AddUser(user);
                Console.WriteLine(user.username + " has created his account!");
            }
            else Console.WriteLine("Username already taken!");
        }

        private void LoginToServer(User user)
        {
            Console.WriteLine(user.username + " logged in to server!");
            if (Server.onlineUsers.Where(x => x.username == user.username).Count() < 1)
                Server.onlineUsers.Add(user);
        }

    }
}
