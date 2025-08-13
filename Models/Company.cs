using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using isg_crm.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace isg_crm.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid Uuid { get; set; } = Guid.NewGuid();

        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyTaxNumber { get; set; }
        public WarningType WarningClass { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("Manager")]
        public Guid ManagerId { get; set; }
        public Manager Manager { get; set; }

    }
    public enum WarningType
    {
        [Description("Az Tehlikeli")]
        AzTehlikeli = 0,
        [Description("Tehlikeli")]
        Tehlikeli = 1,
        [Description("Çok Tehlikeli")]
        CokTehlikeli = 2
    }
}