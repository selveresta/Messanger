using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MessengerCLient
{
    public partial class Form1 : Form
    {

        TcpClient client = null;
        public Form1()
        {
            InitializeComponent();
            btLogin.Enabled = false;
            btLogOut.Enabled = false;
            btSend.Enabled = false;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            client.Connect(adressTB.Text.Trim(), Convert.ToInt32(portTB.Text.Trim()));
            ChatData2.ChatMessage message = new ChatData2.ChatMessage {
                Command = "Login",
                Message = "",
                FromUser = new ChatData2.User { name = textBox1.Text.Trim(), Socket = client },
                ToUser = null,
                DataInfo = "",
                Data = null,
                SentData = DateTime.Now
            };

            var bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, message);
            NetworkStream ns = client.GetStream();
            ns.Write(ms.ToArray(), 0, (int)ms.Length);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 4)
            {
                btLogin.Enabled = false;
                btLogOut.Enabled = false;
                btSend.Enabled = false;
            }
            else
            {
                btLogin.Enabled = true;
                btLogOut.Enabled = true;
                btSend.Enabled = true;
            }
        }
    }
}
