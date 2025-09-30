using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isg_crm.Models
{
    public class Leave
    {
        public Guid Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public Guid EmployeeId { get; set; }
        public Ohs_Employee Employee { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum LeaveType
    {
        Annual = 0,
        Monthly = 1,
        Daily = 2,
        Free = 3
    }

    public enum ApproveStatus
    {
        Pending = 1,
        Accepted = 2,
        Rejected = 3
    }
}