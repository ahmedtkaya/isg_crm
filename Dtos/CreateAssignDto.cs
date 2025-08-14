using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Models;

namespace isg_crm.Dtos
{
    public class CreateAssignDto
    {
        public string? Description { get; set; } // soru işaretini nullable yaptık çünkü girmek istemezse models'deki varsayılan değer kullanılacak
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public StatusType Status { get; set; } = StatusType.Pending;
    }
}