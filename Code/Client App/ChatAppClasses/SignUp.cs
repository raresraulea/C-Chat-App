using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAppClasses
{
    public class SignUp
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
            if (Server_class.serverDatabase.usernameAvailable(user.username))
            {
                Server_class.serverDatabase.AddUser(user);
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
