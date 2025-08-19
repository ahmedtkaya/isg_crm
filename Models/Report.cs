using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace isg_crm.Models
{
    public class Report
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public string ReportType { get; set; }
        public string ReportDescription { get; set; }
        public string ReportFileUrl { get; set; }
        public Guid CompanyId { get; set; }
        public Guid EmployeeId { get; set; }
        public Company Company { get; set; }
        public Ohs_Employee Employee { get; set; }
        public DateTime ControlCheck { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}