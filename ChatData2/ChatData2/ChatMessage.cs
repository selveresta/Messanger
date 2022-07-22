using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatData2
{
    [Serializable]
    public class ChatMessage
    {
        public string Command { get; set; }
        public string Message { get; set; }
        public User FromUser { get; set; }
        public User ToUser { get; set; }
        public byte[] Data { get; set; }
        public string DataInfo { get; set; }
        public DateTime SentData { get; set; }
    }
}
