using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Dtos;
using isg_crm.Models;

namespace isg_crm.Interfaces
{
    public interface IManagerInterface
    {
        Task CreateManagerAsync(Guid managerId, CreateManagerDto createManagerDto);
        Task<bool> IsEmailRegisteredAsync(string email);
        Task<Manager?> GetUserByEmailAsync(string email);
    }
}