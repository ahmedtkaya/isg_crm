using System.ComponentModel.DataAnnotations;
using isg_crm.Controllers;

namespace isg_crm.Models
{
    public class Mission
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public Guid AssignId { get; set; }
        public Guid EmployeeId { get; set; }
        public Ohs_Employee Employee { get; set; }
        public Assignees Assign { get; set; }
        public DateTime ToGoDate { get; set; }
        public string? Description { get; set; }
        public MissionStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


    }
    public enum MissionStatus
    {
        Completed = 0,
        ToGo = 1,
        Pending = 2
    }
}