using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Models;

namespace isg_crm.Dtos
{
    public class UpdateCompanyDto
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyTaxNumber { get; set; }
        public WarningType WarningClass { get; set; }
    }
}