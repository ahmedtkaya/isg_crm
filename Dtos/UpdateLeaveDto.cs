using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Models;

namespace isg_crm.Dtos
{
    public class UpdateLeaveDto
    {
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public string? Description { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}