using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Server
{
    [Serializable]
    public class Message
    {
        private int ID;
        private string type;
        private string sender;
        private string receiver;
        private string messageText;

        public Message()
        {
            type = "public";
            sender = "default";
            receiver = "default";

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
        public string Serialize()
        {
            StreamWriter stWriter = null;
            XmlSerializer xmlSerializer;
            string buffer;
            try
            {
                xmlSerializer = new XmlSerializer(typeof(Message));
                MemoryStream memStream = new MemoryStream();
                stWriter = new StreamWriter(memStream);
                System.Xml.Serialization.XmlSerializerNamespaces xs = new XmlSerializerNamespaces();
                xs.Add("", "");
                
                xmlSerializer.Serialize(stWriter, this, xs);
                buffer = Encoding.ASCII.GetString(memStream.GetBuffer());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                if (stWriter != null)
                    stWriter.Close();
            }
            return buffer;

        }
    }
}
