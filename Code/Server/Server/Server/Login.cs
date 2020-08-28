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

        public string verifyLoginData(User user)
        {
            if (Server_class.serverDatabase.checkCredentials(user.username, user.password))
            {
                if (Server_class.serverDatabase.verifyAdmin(user.username, user.password))
                    return "Welcome, Admin!";
                return "Logged In!";
            }
            else
            {
                //Server_class.sendClientInvLoginMsg();
                return "Wrong Credentials!";
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

    }
}
