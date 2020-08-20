using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class SignUp
    {
        public static SignUp instance = null;
        private SignUp()
        {
        }

        public static SignUp Instance
        {
            get
            {
                if (instance == null)
                    return new SignUp();
                return instance;
            }
        }
        public static string signUp(User user)
        {
            if (Server.serverDatabase.usernameAvailable(user.username))
            {
                Server.serverDatabase.AddUser(user);
                Console.WriteLine(user.username + " has created his account!");
                return "Signed Up Succesfully";
            }
            else
            {
                Console.WriteLine("Username already taken!");
                return "Username already taken";
            }
        }

    }
}
