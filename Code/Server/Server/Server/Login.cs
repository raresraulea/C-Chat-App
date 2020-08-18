using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{

    class Login
    {
        private string username;
        private string password;
        private static Login instance = null;
        public List<User> onlineUsers = new List<User>();

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
                Console.WriteLine("Try Again!");
        }

        private void LoginToServer(User user)
        {
            Console.WriteLine(user.username + "logged in to server!");
        }

        public void verifyPassword(string password)
        {

        }
        public void verifyUsername(string username)
        {

        }
    }
}
