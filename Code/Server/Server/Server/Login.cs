using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Login
    {
        private string username;
        private string password;

        public void editUsername(string username)
        {

        }
        public void editPassword(string newPassword)
        {

        }

        internal void verifyLoginData(string username, string password)
        {
            Server.serverDatabase.checkUsernameAndPassword(username, password);
        }
        public void verifyPassword(string password)
        {

        }
        public void verifyUsername(string username)
        {

        }
    }
}
