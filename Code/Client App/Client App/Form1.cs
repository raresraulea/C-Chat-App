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
        public Dictionary<string, PrivateMessageForm> userForms = new Dictionary<string, PrivateMessageForm>();
        public Dictionary<string, bool> isPMFormOpen = new Dictionary<string, bool>();
        public connectionToServer connection;
        AdminForm adminApp = new AdminForm();
        public User myUser = new User();
        bool startedConnection = false;
        bool loggedIn = false;

        delegate void UserUpdateCallback(string text);
        delegate void MessageUpdateCallback(string text);

        public delegate void LoginUI();
        public LoginUI LoginUIDelegate;

        public delegate void LoginPopup();
        public LoginPopup LoginPopupDelegate;

        public delegate void AdminUI();
        public AdminUI AdminUIDelegate;

        public delegate void WelcomeAdmin();
        public WelcomeAdmin WelcomeAdminPopupDelegate;

        public delegate void WrongCredentialsPopup();
        public WrongCredentialsPopup WrongCredentialsPopupDelegate;

        public delegate void ClearUsersListView();
        public ClearUsersListView ClearUsersListViewDelegate;

        public delegate void DoLogout();
        public DoLogout DoLogoutDelegate;

        public delegate void LogoutPopup();
        public LogoutPopup LogoutPopupDelegate;

        public delegate void UpdateMessages();
        public UpdateMessages UpdateMessagesDelegate;

        Thread loginThread;

        public Form1()
        {
            InitializeComponent();
            IPAddress hostIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            User clientUser = new User();
            clientUser.IP = hostIP.ToString();
            Init();

        }

        private void Init()
        {
            LoginUIDelegate = new LoginUI(ActivateUserInterface_login);
            LoginPopupDelegate = new LoginPopup(showLoginPopup);
            AdminUIDelegate = new AdminUI(ActivateAdminInterface_login);
            WelcomeAdminPopupDelegate = new WelcomeAdmin(showWelcomeAdminPopup);
            WrongCredentialsPopupDelegate = new WrongCredentialsPopup(showWrongCredentialsPopup);
            ClearUsersListViewDelegate = new ClearUsersListView(clearUsersListView);
            DoLogoutDelegate = new DoLogout(doLogout);
            LogoutPopupDelegate = new LogoutPopup(showLogoutPopup);
            UpdateMessagesDelegate = new UpdateMessages(updateMessageListView);
        }

        private void updateMessageListView()
        {
            throw new NotImplementedException();
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
            connection.networkStream.Flush();

            ChatAppClasses.Message messageFromServer;
            messageFromServer = (ChatAppClasses.Message)formatter.Deserialize(connection.networkStream);
            if (messageFromServer.MessageText != "Username already taken")
                showSignUpPopUp();
            else
                showRetrySignUpPopup();

            startedConnection = false;

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

                ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
                messageToSend.MessageText = this.messageBox.Text;
                messageToSend.Type = "Message";
                messageToSend.username = myUser.username;
                formatter.Serialize(connection.networkStream, messageToSend);
                this.messageBox.Text = "";

            }
            catch (Exception exc)
            {

                Console.WriteLine("Failed to send..." + exc.Message);
            }
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            loggedIn = true;
            loginThread = new Thread(() => listenLoggedIn());
            myUser.username = this.UsernameTB.Text;
            myUser.password = this.PasswordTB.Text;

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

                loginThread.Start();
                return;
            }
            else if (LoginBtn.Text == "Logout")
            {
                loggedIn = false;
                adminApp.Visible = false;

                ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
                messageToSend.Type = "Logout";
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize(connection.networkStream, messageToSend);
                connection.networkStream.Flush();

            }
            else
            {
                LoginBtn.Text = "Unknown ERROR";
            }

        }

        public void listenLoggedIn()
        {
            Console.WriteLine("Listen Thread started: Logged In");
            BinaryFormatter formatter = new BinaryFormatter();
            while (loggedIn)
            {
                ChatAppClasses.Message messageFromServer;
                messageFromServer = (ChatAppClasses.Message)formatter.Deserialize(connection.networkStream);

                MyThreadClass myThreadClassObject = new MyThreadClass(this);
                string responseFromServer = messageFromServer.MessageText;

                switch (responseFromServer)
                {
                    case Constants.UserLoginSuccessResponse:
                        myThreadClassObject.Run("LoginUI");
                        myThreadClassObject.Run("LoginPopup");
                        break;
                    case Constants.WelcomeAdminResponse:
                        myThreadClassObject.Run("LoginUI");
                        myThreadClassObject.Run("AdminUI");
                        myThreadClassObject.Run("WelcomeAdminPopup");
                        break;
                    case Constants.WrongCredentialsResponse:
                        myThreadClassObject.Run("WrongCredentialsPopup");
                        loggedIn = false;
                        startedConnection = false;
                        break;
                    case "Logged Out!":
                        myThreadClassObject.Run("DoLogout");
                        myThreadClassObject.Run("ShowLogoutPopup");
                        loggedIn = false;
                        break;

                }

                switch (messageFromServer.Type)
                {
                    case "List":
                        foreach (var user in messageFromServer.onlineUser)
                        {
                            if (!userForms.ContainsKey(user))
                            {
                                PrivateMessageForm formToAdd = new PrivateMessageForm(this, user);
                                formToAdd.Name = user;
                                userForms.Add(user, formToAdd);
                                isPMFormOpen.Add(user, false);
                                Console.WriteLine("added form for " + user);
                            }
                        }
                        updateOnlineUsers(messageFromServer);
                        break;
                    case "broadcastMessage":
                        UpdateBroadcastedMessage(messageFromServer);
                        break;
                    case "PrivateMessage":
                        PrivateMessageForm form = userForms[messageFromServer.Sender];
                        if (!isPMFormOpen[messageFromServer.Sender])
                        {
                            Console.WriteLine("Nu e deschis!");
                            form.MessagesListView.Items.Add(messageFromServer.MessageText);
                            form.ShowDialog();
                            isPMFormOpen[messageFromServer.Sender] = true;
                        }
                        else
                        {
                            Console.WriteLine("SUNT BINE!");
                            form.Hide();
                            form.MessagesListView.Items.Add(messageFromServer.MessageText);
                            form.ShowDialog();
                        }
                        break;
                }

            }
            Console.WriteLine("Listen Thread stopped: Logged Out");
            loginThread.Abort();
        }
        public bool IsFormOpen(PrivateMessageForm myForm)
        {
            foreach (PrivateMessageForm form in Application.OpenForms)
                if (form.Name == myForm.Name)
                {
                    Console.WriteLine(form.Name + " " + myForm.Name);
                    return true;
                }
            return false;
        }

        private static void showWrongCredentialsPopup()
        {
            Popup popup = new Popup();
            popup.BackColor = Constants.WrongCredentialsPopupColor;
            popup.message.Text = "wrong Credentials!";
            popup.Show();
        }

        private void UpdateUsers(string user)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.onlineUsersLV.InvokeRequired)
            {
                UserUpdateCallback userUpdate = new UserUpdateCallback(UpdateUsers);
                this.Invoke(userUpdate, new object[] { user });
            }
            else
            {
                this.onlineUsersLV.Items.Add(user);
            }
        }
        private void updateOnlineUsers(ChatAppClasses.Message messageFromServer)
        {
            if (messageFromServer.Type == "List")
            {
                MyThreadClass myThreadClassObject = new MyThreadClass(this);
                myThreadClassObject.Run("ClearUsersListView");
                foreach (var user in messageFromServer.onlineUser)
                {
                    UpdateUsers(user);
                }
            }
        }
        private void UpdateBroadcastedMessage(ChatAppClasses.Message messageFromServer)
        {
            if (messageFromServer.Type == "broadcastMessage")
            {
                MyThreadClass myThreadClassObject = new MyThreadClass(this);

                UpdateMessagesWithDelegate(messageFromServer.MessageText);

            }
        }
        private void UpdateMessagesWithDelegate(string message)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                MessageUpdateCallback messageUpdate = new MessageUpdateCallback(UpdateMessagesWithDelegate);
                this.Invoke(messageUpdate, new object[] { message });
            }
            else
            {
                this.MessagesListView.Items.Add(message);
            }
        }

        private void clearUsersListView()
        {
            this.onlineUsersLV.Clear();
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
            this.ConnectionLabel.Text = "Disconnected";
            this.ConnectionLabel.ForeColor = Color.DarkRed;

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

        //private void onlineUsersLV_ItemActivate(object sender, EventArgs e)
        //{
        //    int otherParticipant_index = onlineUsersLV.SelectedIndices[0];
        //    string otherParticipant_username = onlineUsersLV.Items[otherParticipant_index].Text;
        //    PrivateMessageForm privateMessageForm = new PrivateMessageForm(otherParticipant_username);
        //    privateMessageForm.Show();
        //}

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
            this.SignUpBtn.Visible = true;
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
            adminApp.Show();
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

            this.ConnectionLabel.Text = "Connected";
            this.ConnectionLabel.ForeColor = Color.MediumSeaGreen;
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
            SettingForm settingForm = new SettingForm(this);
            settingForm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void onlineUsersLV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (onlineUsersLV.SelectedItems.Count > 0)
            {
                int otherParticipant_index = onlineUsersLV.SelectedIndices[0];
                string otherParticipant_username = onlineUsersLV.Items[otherParticipant_index].Text;
                PrivateMessageForm privateMessageForm = new PrivateMessageForm(this, otherParticipant_username);
                privateMessageForm.Show();

                isPMFormOpen[onlineUsersLV.Items[otherParticipant_index].Text] = true;
            }
        }
    }
}
