using System;
using System.Collections.Generic;
using System.Linq;
using isg_crm.Models;

namespace isg_crm.Dtos
{
    public class CreateLeaveDto
    {
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public Guid EmployeeId { get; set; }
        public string? Description { get; set; }
        public LeaveType LeaveType { get; set; }
        public ApproveStatus Status { get; set; }
    }
}