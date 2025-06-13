using System;
using System.Collections.Generic;

namespace BaiTap4OnlineSo2.Models
{
    public partial class Assignment
    {
        public string Code { get; set; } = null!;
        public string? Customername { get; set; }
        public string? Customeremail { get; set; }
        public string? Telephone { get; set; }
        public DateTime Assignmentdate { get; set; }
        public DateTime? Expiredate { get; set; }
        public short? Status { get; set; }
        public string? Servicecode { get; set; }
        public string? Devicecode { get; set; }

        public virtual Device? DevicecodeNavigation { get; set; }
        public virtual Service? ServicecodeNavigation { get; set; }
    }
}
