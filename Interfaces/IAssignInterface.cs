using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Dtos;
using isg_crm.Models;

namespace isg_crm.Interfaces
{
    public interface IAssignInterface
    {
        Task<Guid> CreateAssignAsync(Guid employeeId, Guid companyId, CreateAssignDto createAssignDto);
        Task<IEnumerable<Assignees>> GetAllAssignsAsync();
        Task DeleteAssignAsync(Guid id);
        Task<IEnumerable<Assignees>> GetByAssignFromEmployeeId(Guid employeeId);

        Task<Assignees?> GetAssignByIdAsync(Guid id);
        Task UpdateAsync(Assignees assignees);
    }
}