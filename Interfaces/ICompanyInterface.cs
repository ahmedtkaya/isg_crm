using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Dtos;
using isg_crm.Models;

namespace isg_crm.Interfaces
{
    public interface ICompanyInterface
    {
        Task CreateCompanyAsync(Guid managerId, CreateCompanyDto createCompanyDto);
        Task<Company> GetCompanyByIdAsync(Guid id);
        Task<IEnumerable<Company>> GetAllCompaniesAsync();
        Task DeleteCompanyAsync(Guid id);
        Task UpdateCompanyAsync(Guid id, UpdateCompanyDto updateCompanyDto);

    }
}