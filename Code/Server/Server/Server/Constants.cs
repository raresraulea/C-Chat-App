using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Constants
    {
        public const string messageType_connection = "Connection";
        public const string messageType_message = "Message";
        public const string messageType_login = "Login";
        public const string messageType_logout = "Logout";
        public const string messageType_signUp = "SignUp";
        public const string messageType_broadcastMessage = "broadcastMessage";
        public const string response_wrongCredentials = "Wrong Credentials!";
    }
}
