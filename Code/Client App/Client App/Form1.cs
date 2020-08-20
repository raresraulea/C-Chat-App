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
        public Form1()
        {
            InitializeComponent();
			IPAddress hostIP = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
		}
	
		private void button1_Click(object sender, EventArgs e)
        {
			try
			{
				TcpClient client = new TcpClient(Dns.GetHostName(), 1302);
				BinaryFormatter formatter = new BinaryFormatter();
				NetworkStream networkStream = client.GetStream();

				ChatAppClasses.Message messageToSend = new ChatAppClasses.Message();
				messageToSend.MessageText = this.messageBox.Text;
				messageToSend.Sender = "TrimitatorDeMesaje";
				messageToSend.Receiver = "PrimitorDeMesaje";
				formatter.Serialize(networkStream, messageToSend);
				this.messageBox.Text = "";

				//int byteCount = Encoding.ASCII.GetByteCount(messageToSend);
				//byte[] sendData = new byte[byteCount + 1];
				//sendData = Encoding.ASCII.GetBytes(messageToSend);

				//networkStream.Write(sendData, 0, sendData.Length);
				//Console.WriteLine("Sending data to the server...");

				StreamReader streamReader = new StreamReader(networkStream);
				string responseFromServer = streamReader.ReadLine();
				Console.WriteLine(responseFromServer);

				networkStream.Close();
				client.Close();
			}
			catch (Exception exc)
			{

				Console.WriteLine("failed to connect..." + exc.Message);
			}
		}
    }
}
