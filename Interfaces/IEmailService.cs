using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace isg_crm.Interfaces
{
    public interface IEmailService
    {
        Task SendPasswordEmailAsync(string toEmail, string password);
    }

}