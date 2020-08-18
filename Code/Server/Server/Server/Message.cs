using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Message
    {
        private int ID;
        private string type;
        private User sender;
        private User receiver;
        private string text;

        public void setText(string text)
        {
            this.text = text;
        }

    }
}
