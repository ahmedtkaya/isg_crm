using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Models;

namespace isg_crm.Dtos
{
    public class CreateMissionDto
    {
        public DateTime ToGoDate { get; set; }
        public string? Description { get; set; }
        public MissionStatus Status { get; set; }
        public Guid AssignId { get; set; }
    }
}