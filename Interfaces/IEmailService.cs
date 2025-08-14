using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isg_crm.Interfaces
{
    public interface IEmailService
    {
        Task SendPasswordEmailAsync(string toEmail, string password);
        Task SendAssignEmailAsync(string toEmail, string companyName, string companyAddress, string employeeName, string description);
    }

}