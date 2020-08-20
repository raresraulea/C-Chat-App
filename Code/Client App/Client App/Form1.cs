using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using ChatAppClasses;

namespace Client_App
{
    public partial class Form1 : Form
    {
        connectionToServer connection;

        public Form1()
        {
            InitializeComponent();
            IPAddress hostIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            User clientUser = new User();
            clientUser.IP = hostIP.ToString();
            label7.Text = Dns.GetHostName();
        }
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new connectionToServer();
                string hostAddress = this.IPAddressTB.Text;
                if (hostAddress == "this" || hostAddress == "localhost")
                    connection.client = new TcpClient(Dns.GetHostName(), int.Parse(this.PortTB.Text));
                connection.networkStream = connection.client.GetStream();
                BinaryFormatter formatter = new BinaryFormatter();

                ConnectionLabel.Text = "Wait...";
                ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
                messageToSend.MessageText = "Connection Request";
                messageToSend.Type = "Connection";
                formatter.Serialize(connection.networkStream, messageToSend);

                StreamReader streamReader = new StreamReader(connection.networkStream);
                string responseFromServer = streamReader.ReadLine();
                this.ConnectionLabel.Text = responseFromServer;
                ActivateConnectionInterface();
                connection.networkStream.Flush();
                connection.networkStream.Close();
                connection.client.Close();

            }
            catch (Exception exc)
            {

                Console.WriteLine("failed to connect..." + exc.Message);
            }
        }
        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            this.LoginBtn.Enabled = false;
            LoginBtn.BackColor = Constants.Inactive;
            this.SignUpBtn.Enabled = false;
            this.SignUpBtn.BackColor = Constants.Inactive;
            this.ConnectionLabel.Text = "Not Connected";
            this.ConnectionLabel.ForeColor = Color.Red;
            this.DisconnectBtn.Enabled = false;
            this.ConnectBtn.Enabled = true;
            this.label7.Text = "Bye Bye!";
            DisconnectBtn.BackColor = Color.FromArgb(20, 255, 0, 0);
            ConnectBtn.BackColor = Constants.ConnectBtnActive;
        }
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            connection = new connectionToServer();
            string hostAddress = this.IPAddressTB.Text;
            if (hostAddress == "this" || hostAddress == "localhost")
                connection.client = new TcpClient(Dns.GetHostName(), int.Parse(this.PortTB.Text));
            connection.networkStream = connection.client.GetStream();
            BinaryFormatter formatter = new BinaryFormatter();

            ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
            messageToSend.MessageText = "Sign Up Request";
            messageToSend.Type = "SignUp";
            messageToSend.username = UsernameTB.Text.ToString();
            messageToSend.password = PasswordTB.Text.ToString();

            formatter.Serialize(connection.networkStream, messageToSend);

            StreamReader streamReader = new StreamReader(connection.networkStream);
            string responseFromServer = streamReader.ReadLine();
            this.label7.Text = responseFromServer;
            
            connection.networkStream.Close();
            connection.client.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //TcpClient client = new TcpClient(Dns.GetHostName(), 1302);
                BinaryFormatter formatter = new BinaryFormatter();
                //NetworkStream networkStream = client.GetStream();

                ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
                messageToSend.MessageText = this.messageBox.Text;
                messageToSend.Type = "Message";
                formatter.Serialize(connection.networkStream, messageToSend);
                this.messageBox.Text = "";

                //int byteCount = Encoding.ASCII.GetByteCount(messageToSend);
                //byte[] sendData = new byte[byteCount + 1];
                //sendData = Encoding.ASCII.GetBytes(messageToSend);

                //networkStream.Write(sendData, 0, sendData.Length);
                //Console.WriteLine("Sending data to the server...");

                StreamReader streamReader = new StreamReader(connection.networkStream);
                string responseFromServer = streamReader.ReadLine();
                Console.WriteLine(responseFromServer);

                connection.networkStream.Close();
                connection.client.Close();
            }
            catch (Exception exc)
            {

                Console.WriteLine("failed to send..." + exc.Message);
            }
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            connection = new connectionToServer();
            string hostAddress = this.IPAddressTB.Text;
            if (hostAddress == "this" || hostAddress == "localhost")
                connection.client = new TcpClient(Dns.GetHostName(), int.Parse(this.PortTB.Text));
            connection.networkStream = connection.client.GetStream();
            BinaryFormatter formatter = new BinaryFormatter();

            ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
            generateLoginMessage(messageToSend);

            formatter.Serialize(connection.networkStream, messageToSend);

            StreamReader streamReader = new StreamReader(connection.networkStream);
            string responseFromServer = streamReader.ReadLine();
            this.label7.Text = responseFromServer;
            if (responseFromServer == "Logged In!")
            {
                ActivateUserInterface();
            }
            else if (responseFromServer == "Welcome, Admin!")
            {
                ActivateUserInterface();
                ActivateAdminInterface();

            }
            connection.networkStream.Close();
            connection.client.Close();
        }
        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            this.UsernameTB.Enabled = true;
            this.UsernameTB.BackColor = Constants.TBActive;

            this.PasswordTB.Enabled = true;
            this.PasswordTB.BackColor = Constants.TBActive;

            this.BlockBtn.Enabled = false;
            this.BlockBtn.BackColor = Constants.Inactive;

            this.WarnBtn.Enabled = false;
            this.WarnBtn.BackColor = Constants.Inactive;

            this.DeleteAccBtn.Enabled = false;
            this.DeleteAccBtn.BackColor = Constants.Inactive;

            this.AdminBoardUsernameTB.Enabled = false;
            this.AdminBoardUsernameTB.BackColor = Constants.Inactive;

            this.LogoutBtn.Enabled = false;
            this.LogoutBtn.BackColor = Constants.Inactive;


            this.UsernameTB.Text = String.Empty;
            this.PasswordTB.Text = String.Empty;

            this.LoginBtn.Enabled = true;
            this.LoginBtn.BackColor = Constants.LoginBtnActive; // Color.MediumSeaGreen;

            this.SignUpBtn.Enabled = true;
            this.SignUpBtn.BackColor = Constants.SignUpBtnActive; //Color.RoyalBlue;

            this.messageBox.Enabled = false;
            this.messageBox.BackColor = Constants.Inactive; //Color.LightGray;

            this.sendMessageButton.Enabled = false;
            this.sendMessageButton.BackColor = Constants.Inactive;
        }
        private void generateLoginMessage(ChatAppClasses.Message messageToSend)
        {
            messageToSend.MessageText = "Login Request";
            messageToSend.Type = "Login";
            messageToSend.username = UsernameTB.Text.ToString();
            messageToSend.password = PasswordTB.Text.ToString();
        }
        private void ActivateConnectionInterface()
        {
            this.label7.Text = "Now You can Log In!";
            this.ConnectionLabel.ForeColor = Color.Green;
            this.DisconnectBtn.Enabled = true;
            this.ConnectBtn.Enabled = false;
            this.LoginBtn.Enabled = true;
            this.LoginBtn.BackColor = Constants.LoginBtnActive;
            this.SignUpBtn.Enabled = true;
            this.SignUpBtn.BackColor = Constants.SignUpBtnActive;
            this.UsernameTB.Enabled = true;
            this.PasswordTB.Enabled = true;
            this.ConnectBtn.BackColor = Color.FromArgb(20, 255, 0, 0);
            this.DisconnectBtn.BackColor = Constants.DisconnectBtnActive;
            this.UsernameTB.BackColor = Constants.TBActive;
            this.PasswordTB.BackColor = Constants.TBActive;
        }
        private void ActivateAdminInterface()
        {
            this.UsernameTB.Enabled = false;
            this.UsernameTB.BackColor = Constants.Inactive;

            this.PasswordTB.Enabled = false;
            this.PasswordTB.BackColor = Constants.Inactive;

            this.BlockBtn.Enabled = true;
            this.BlockBtn.BackColor = Color.LightCoral;

            this.WarnBtn.Enabled = true;
            this.WarnBtn.BackColor = Constants.WarnBtnActive;// Color.LightSalmon;

            this.DeleteAccBtn.Enabled = true;
            this.DeleteAccBtn.BackColor = Color.OrangeRed;

            this.AdminBoardUsernameTB.Enabled = true;
            this.AdminBoardUsernameTB.BackColor = Constants.TBActive;

            this.LogoutBtn.Enabled = true;
            this.LogoutBtn.BackColor = Constants.LogoutBtnActive;
        }
        private void ActivateUserInterface()
        {
            this.UsernameTB.Text = String.Empty;
            this.PasswordTB.Text = String.Empty;

            this.LoginBtn.Enabled = false;
            this.LoginBtn.BackColor = Constants.Inactive;

            this.LogoutBtn.Enabled = true;
            this.LogoutBtn.BackColor = Constants.LogoutBtnActive;

            this.SignUpBtn.Enabled = false;
            this.SignUpBtn.BackColor = Constants.Inactive;

            this.messageBox.Enabled = true;
            this.messageBox.BackColor = Constants.TBActive;// Color.White;

            this.sendMessageButton.Enabled = true;
            this.sendMessageButton.BackColor = Constants.sendMsgBtnActive;// Color.LightBlue;
        }
        private void messageBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        
    }
}
