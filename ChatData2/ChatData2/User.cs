using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatData2
{
    [Serializable]
    public class User
    {
        public string name { get; set; }
        public TcpClient Socket { get; set; }
    }
}
