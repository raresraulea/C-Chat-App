using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Message
    {
        private int ID;
        private string type;
        private string sender;
        private string receiver;
        private string messageText;

        public Message()
        {
        }

        public Message(string messageText)
        {
            this.MessageText = messageText;
        }

        public Message(string messageText, string destinationUser) : this(messageText)
        {
            this.Receiver = destinationUser;
        }

        public string MessageText { get => messageText; set => messageText = value; }
        public string Receiver { get => receiver; set => receiver = value; }
        public string Sender { get => sender; set => sender = value; }

        public void setText(string text)
        {
            this.MessageText = text;
        }

    }
}
