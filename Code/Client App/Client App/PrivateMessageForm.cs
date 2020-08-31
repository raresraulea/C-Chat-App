using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_App
{
    public partial class PrivateMessageForm : Form
    {
        private string otherParticipant;
        private Form1 form;
        public PrivateMessageForm()
        {
            InitializeComponent();

        }
        public PrivateMessageForm(Form1 form, string otherParticipant)
        {
            InitializeComponent();
            this.otherParticipant = otherParticipant;
            this.PrivateChatTitle.Text += " " + otherParticipant;

            this.form = form;
            this.FormClosing += PrivateMessageForm_FormClosing;
        }

        private void PrivateMessageForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //In case windows is trying to shut down, don't hold the process up
           
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.WindowsShutDown)
            {
                form.isPMFormOpen[this.Name] = false;
            }

        }
        private void PrivateMessageForm_Load(object sender, EventArgs e)
        {

        }

        private void PrivateChatTitle_Click(object sender, EventArgs e)
        {

        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
            messageToSend.Sender = form.myUser.username;
            messageToSend.Receiver = this.otherParticipant;
            messageToSend.MessageText = this.messageBox.Text;
            messageToSend.Type = "PrivateMessage";

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(form.connection.networkStream, messageToSend);
            form.connection.networkStream.Flush();
        }

        private void MessagesListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
