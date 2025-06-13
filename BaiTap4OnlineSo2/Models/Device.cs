using System;
using System.Collections.Generic;

namespace BaiTap4OnlineSo2.Models
{
    public partial class Device
    {
        public Device()
        {
            Assignments = new HashSet<Assignment>();
        }

        public string Devicecode { get; set; } = null!;
        public string? Devicename { get; set; }
        public string? Ipaddress { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? Connected { get; set; }
        public bool? Operationstatus { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
