using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace isg_crm.Models
{
    public class Manager
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public ManagerType Type { get; set; } = ManagerType.Manager;
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


    }

    public enum ManagerType
    {
        [Description("Manager")]
        Manager = 0,
        [Description("Admin")]
        Admin = 1,
        [Description("Super Admin")]
        SuperAdmin = 2
    }
}