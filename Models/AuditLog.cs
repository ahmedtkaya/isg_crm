using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isg_crm.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Method { get; set; } = string.Empty;
        public string? Query { get; set; }
        public string? Body { get; set; }
        public string? User { get; set; }
        public string? IpAddress { get; set; }
        public int StatusCode { get; set; }
        public string? ResponseBody { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}