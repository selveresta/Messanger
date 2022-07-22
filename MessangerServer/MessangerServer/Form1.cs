using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatData2;

namespace MessangerServer
{
    public partial class Form1 : Form
    {
        TcpListener listener = null;
        Semaphore semaphore = new Semaphore(10, 10);
        static List<User> users = new List<User>(); 
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adress = adressTB.Text;
            if (string.IsNullOrEmpty(adressTB.Text))
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        adress = ip.ToString();
                        break;
                    }
                    MessageBox.Show(adress);
                }
            }
            listener = new TcpListener(IPAddress.Parse(adress), Convert.ToInt32(portTB.Text.Trim()));
            listener.Start();
            while (true)
            {
                semaphore.WaitOne();
                Thread thread = new Thread(Listen);
                thread.IsBackground = true;
                thread.Start();
                semaphore.Release();
            }
        }

        private void Listen()
        {
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream ns = client.GetStream();
            var binaryFormatter = new BinaryFormatter();
            StreamReader sr = new StreamReader(ns, Encoding.UTF8);
            ChatMessage chatMessage = (ChatMessage)binaryFormatter.Deserialize(sr.BaseStream);
            switch (chatMessage.Command)
            {
                case "Login":

                    break;
                case "Logout":
                    break;
                case "Message":
                    break;
                case "Refresh":
                    break;
                default:
                    break;
            }

            semaphore.Release();
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
