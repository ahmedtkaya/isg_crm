using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Dtos;
using isg_crm.Models;

namespace isg_crm.Interfaces
{
    public interface ILeaveInterface
    {
        Task<Leave> CreateLeaveAsync(CreateLeaveDto createLeaveDto);
        Task<IEnumerable<Leave>> GetAllLeavesAsync();
        Task<Leave?> GetLeaveByIdAsync(Guid id);
        Task DeleteLeaveAsync(Guid id);
        Task<IEnumerable<Leave>> GetByLeaveFromEmployeeId(Guid employeeId);
    }
}
//istediğimiz izni id e göre güncelleyebileceğiz(sadece admin)