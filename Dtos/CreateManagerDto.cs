using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Models;

namespace isg_crm.Dtos
{
    public class CreateManagerDto
    {
        public string Email { get; set; }
        public ManagerType Type { get; set; } = ManagerType.Manager;
        public string Name { get; set; }
        public string Password { get; set; }
    }
}