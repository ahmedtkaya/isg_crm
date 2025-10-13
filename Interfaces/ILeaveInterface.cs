using System;
using System.Collections.Generic;
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
        Task<bool> UpdateLeaveStatusAsync(Guid id, ApproveStatus status);

        Task<bool> UpdateLeaveAsync(Guid id, UpdateLeaveDto updateLeaveDto);
    }
}
