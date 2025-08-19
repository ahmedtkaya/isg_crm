using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace isg_crm.Dtos
{
    public class CreateReportDto
    {
        [Required]
        public string? ReportType { get; set; } // soru işaretini null için koydum yoksa altı sarı çiziliyor bir bakalım buna
        [Required]
        public string? ReportDescription { get; set; }
        // [Required]
        // public string? ReportFileUrl { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        public DateTime ControlCheck { get; set; }
    }
}