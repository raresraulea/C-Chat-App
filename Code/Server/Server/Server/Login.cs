using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public class Login
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
            if (Server_class.serverDatabase.checkCredentials(user.username, user.password))
            {
                updateOnlineUsers(user);
            }
            else
            {
                Server_class.sendClientInvLoginMsg();
            }
        }

        private void SignUp(User user)
        {
            if (Server_class.serverDatabase.usernameAvailable(user.username))
            {
                Server_class.serverDatabase.AddUser(user);
                Console.WriteLine(user.username + " has created his account!");
            }
            else Console.WriteLine("Username already taken!");
        }

        private void updateOnlineUsers(User user)
        {
            Console.WriteLine(user.username + " logged in to server!");
            if (Server_class.onlineUsers.Where(x => x.username == user.username).Count() < 1)
                Server_class.onlineUsers.Add(user);
        }

    }
}
