using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isg_crm.Dtos
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; } //burası otomatik atanacak ve atanan şifre mail gidecek o yüzden geçici olarak tutulacak şuan
        public string IdentityNumber { get; set; }
        public string Mission { get; set; }
        public int CertificateNumber { get; set; }
        public DateTime CertificateDate { get; set; }
    }
}