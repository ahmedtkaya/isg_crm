using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isg_crm.Models
{
    public class Assignees
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public string Description { get; set; } = "Bu şirket iş sağlığı güvenliği kapsamında denetime girecektir."; //default değer verememiş burayı incele
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public Company Company { get; set; }
        public Ohs_Employee Employee { get; set; }
        public StatusType Status { get; set; } = StatusType.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum StatusType
    {
        Completed = 0,
        Accepted = 1,
        Pending = 2
    }
}