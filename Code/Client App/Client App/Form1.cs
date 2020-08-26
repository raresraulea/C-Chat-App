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
        private connectionToServer connection;
        AdminForm adminApp = new AdminForm();
        bool startedConnection = false;

        public Form1()
        {
            InitializeComponent();
            IPAddress hostIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            User clientUser = new User();
            clientUser.IP = hostIP.ToString();

        }
        

        private static void showDisconnectPopup()
        {
            Popup popup = new Popup();
            popup.BackColor = Constants.DisconnectPopupColor;
            popup.message.Text = "Disconnected!";
            popup.Show();
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            updateUI_disconnect();
        }

        private void updateUI_disconnect()
        {
            this.LoginBtn.Enabled = false;
            LoginBtn.BackColor = Constants.Inactive;
            this.SignUpBtn.Enabled = false;
            this.SignUpBtn.BackColor = Constants.Inactive;
            this.ConnectionLabel.Text = "Not Connected";
            this.ConnectionLabel.ForeColor = Color.Red;
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            if (!startedConnection)
            {
                startedConnection = true;
                connection = new connectionToServer();
                connection.client = new TcpClient(Dns.GetHostName(), connection.port);
                connection.networkStream = connection.client.GetStream();
            }
            BinaryFormatter formatter = new BinaryFormatter();

            ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
            messageToSend.MessageText = "Sign Up Request";
            messageToSend.Type = "SignUp";
            messageToSend.username = UsernameTB.Text.ToString();
            messageToSend.password = PasswordTB.Text.ToString();

            formatter.Serialize(connection.networkStream, messageToSend);

            StreamReader streamReader = new StreamReader(connection.networkStream);
            string responseFromServer = streamReader.ReadLine();
            if (responseFromServer != "Username already taken")
                showSignUpPopUp();
            else
                showRetrySignUpPopup();

            connection.networkStream.Close();
            connection.client.Close();
        }

        private void showRetrySignUpPopup()
        {
            Popup popup = new Popup();
            popup.BackColor = Constants.LogoutBtnActive;
            popup.message.Text = "Username already taken. Retry!";
            popup.Show();
        }

        private static void showSignUpPopUp()
        {
            Popup popup = new Popup();
            popup.BackColor = Constants.SignUpPopupColor;
            popup.message.Text = "Signed Up!";
            popup.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!startedConnection)
                {
                    startedConnection = true;
                    connection = new connectionToServer();
                    connection.client = new TcpClient(Dns.GetHostName(), connection.port);
                    connection.networkStream = connection.client.GetStream();
                }
                BinaryFormatter formatter = new BinaryFormatter();
                //TcpClient client = new TcpClient(Dns.GetHostName(), 1302);


                //NetworkStream networkStream = client.GetStream();

                ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
                messageToSend.MessageText = this.messageBox.Text;
                messageToSend.Type = "Message";
                messageToSend.username = "standard";
                formatter.Serialize(connection.networkStream, messageToSend);
                this.messageBox.Text = "";
                //Thread.Sleep(50);
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

            if (this.LoginBtn.Text == "Login")
            {
                if (!startedConnection)
                {
                    startedConnection = true;
                    connection = new connectionToServer();
                    connection.client = new TcpClient(Dns.GetHostName(), connection.port);
                    connection.networkStream = connection.client.GetStream();
                }

                ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
                generateLoginMessage(messageToSend);

                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(connection.networkStream, messageToSend);
                connection.networkStream.Flush();

                ChatAppClasses.Message messageFromServer;
                messageFromServer = (ChatAppClasses.Message)formatter.Deserialize(connection.networkStream);

                string responseFromServer = messageFromServer.MessageText;
                switch (responseFromServer)
                {
                    case "Logged In!":
                        ActivateUserInterface_login();
                        showLoginPopup();
                        break;
                    case "Welcome, Admin!":
                        adminApp.Show();
                        ActivateUserInterface_login();
                        ActivateAdminInterface_login();
                        showWelcomeAdminPopup();
                        break;
                    case "Wrong Credentials!":
                        {
                            Popup popup = new Popup();
                            popup.BackColor = Constants.WrongCredentialsPopupColor;
                            popup.message.Text = "wrong Credentials!";
                            popup.Show();
                            break;
                        }
                    case "Logged out!":

                        break;
                }
                Console.WriteLine("Am ajuns aici");
                //connection.networkStream.Close();
                //connection.client.Close();
            }
            else if (LoginBtn.Text == "Logout")
            {
                adminApp.Visible = false;
                
                ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
                messageToSend.Type = "Logout";
                IFormatter formatter = new BinaryFormatter();
                
                formatter.Serialize(connection.networkStream, messageToSend);
                connection.networkStream.Flush();

                ChatAppClasses.Message messageFromServer;
                messageFromServer = (ChatAppClasses.Message)formatter.Deserialize(connection.networkStream);

                if(messageFromServer.MessageText == "Logged Out!")
                {
                doLogout();
                showLogoutPopup();
                }
            }
            else
            {
                LoginBtn.Text = "Unknown ERROR";
            }

        }

        private static void showLogoutPopup()
        {
            Popup popup = new Popup();
            popup.BackColor = Constants.LogoutPopupColor;
            popup.message.Text = "Logged Out!";
            popup.Show();
        }

        private static void showWelcomeAdminPopup()
        {
            Popup popup = new Popup();
            popup.BackColor = Constants.LoginPopupColor;
            popup.message.Text = "Welcome Admin!";
            popup.Show();
        }

        private static void showLoginPopup()
        {
            Popup popup = new Popup();
            popup.BackColor = Constants.LoginPopupColor;
            popup.message.Text = "Logged In!";
            popup.Show();
        }

        private void doLogout()
        {
            LogoutActivations();
            LogoutDeactivations();
            startedConnection = false;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.BackColor = Constants.LoginBtnActive;
            this.UsernameTB.Text = String.Empty;
            this.PasswordTB.Text = String.Empty;

        }

        private void LogoutDeactivations()
        {
            this.messageBox.Enabled = false;
            this.messageBox.BackColor = Constants.Inactive;

            this.sendMessageButton.Enabled = false;
            this.sendMessageButton.BackColor = Constants.Inactive;
        }

        private void LogoutActivations()
        {
            this.UsernameTB.Enabled = true;
            this.UsernameTB.BackColor = Constants.TBActive;

            this.PasswordTB.Enabled = true;
            this.PasswordTB.BackColor = Constants.TBActive;

            this.SignUpBtn.Enabled = true;
            this.SignUpBtn.BackColor = Constants.SignUpBtnActive;
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {

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
            this.ConnectionLabel.ForeColor = Color.Green;
            this.LoginBtn.Enabled = true;
            this.LoginBtn.BackColor = Constants.LoginBtnActive;
            this.SignUpBtn.Enabled = true;
            this.SignUpBtn.BackColor = Constants.SignUpBtnActive;
            this.UsernameTB.Enabled = true;
            this.PasswordTB.Enabled = true;
            this.UsernameTB.BackColor = Constants.TBActive;
            this.PasswordTB.BackColor = Constants.TBActive;
        }
        private void ActivateAdminInterface_login()
        {
            this.UsernameTB.Enabled = false;
            this.UsernameTB.BackColor = Constants.Inactive;

            this.PasswordTB.Enabled = false;
            this.PasswordTB.BackColor = Constants.Inactive;

        }
        private void ActivateUserInterface_login()
        {
            this.UsernameTB.Text = String.Empty;
            this.PasswordTB.Text = String.Empty;

            this.LoginBtn.Text = "Logout";
            this.LoginBtn.BackColor = Constants.LogoutBtnActive;

            this.SignUpBtn.Enabled = false;
            this.SignUpBtn.Visible = false;
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

        //internal static void updateSettings(string IP, int port)
        //{
        //    connection.port = port;
        //    connection.IPAddress = IP;
        //}

        private void button1_Click_2(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.Show();
        }
    }
}
