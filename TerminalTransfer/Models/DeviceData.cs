using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTransfer.Models
{
    public class DeviceData
    {
        public bool Select { get; set; }  // Make sure this is a boolean type
        public string TerminalNo { get; set; }
        public string TerminalAdi { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public bool hafizasil { get; set;  }
    }

}
