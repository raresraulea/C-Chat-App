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

                ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
                messageToSend.MessageText = this.messageBox.Text;
                messageToSend.Sender = "TrimitatorDeMesaje";
                messageToSend.Receiver = "PrimitorDeMesaje";
                messageToSend.Type = "Connection";
                formatter.Serialize(connection.networkStream, messageToSend);
                this.messageBox.Text = "";

                StreamReader streamReader = new StreamReader(connection.networkStream);
                string responseFromServer = streamReader.ReadLine();
                this.ConnectionLabel.Text = responseFromServer;
                this.ConnectionLabel.ForeColor = Color.Green;
                this.DisconnectBtn.Enabled = true;
                this.ConnectBtn.Enabled = false;
                ConnectBtn.BackColor = Color.FromArgb(20, 255, 0, 0);
                DisconnectBtn.BackColor = Color.LightSalmon;
                connection.networkStream.Close();

            }
            catch (Exception exc)
            {

                Console.WriteLine("failed to connect..." + exc.Message);
            }
        }
        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            this.ConnectionLabel.Text = "Not Connected";
            this.ConnectionLabel.ForeColor = Color.Red;
            this.DisconnectBtn.Enabled = false;
            this.ConnectBtn.Enabled = true;
            DisconnectBtn.BackColor = Color.FromArgb(20, 255, 0, 0);
            ConnectBtn.BackColor = Color.MediumSeaGreen;
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
                messageToSend.Sender = "TrimitatorDeMesaje";
                messageToSend.Receiver = "PrimitorDeMesaje";
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
