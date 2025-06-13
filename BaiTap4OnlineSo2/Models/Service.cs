using System;
using System.Collections.Generic;

namespace BaiTap4OnlineSo2.Models
{
    public partial class Service
    {
        public Service()
        {
            Assignments = new HashSet<Assignment>();
        }

        public string Servicecode { get; set; } = null!;
        public string? Servicename { get; set; }
        public string? Description { get; set; }
        public bool? Isinoperation { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
