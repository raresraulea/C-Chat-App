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





        public void editUsername(string username)
        {

        }
        public void editPassword(string newPassword)
        {

        }

        public void verifyLoginData(string username, string password)
        {
            Server.serverDatabase.checkCredentials(username, password);
        }
        public void verifyPassword(string password)
        {

        }
        public void verifyUsername(string username)
        {

        }
    }
}
