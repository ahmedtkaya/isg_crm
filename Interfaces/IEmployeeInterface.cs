using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Dtos;
using isg_crm.Models;

namespace isg_crm.Interfaces
{
    public interface IEmployeeInterface
    {
        Task CreateEmployeeAsync(Guid managerId, CreateEmployeeDto employeeDto);
        Task DeleteEmployeeAsync(Guid id);
        Task<IEnumerable<Ohs_Employee>> GetAllEmployeesAsync();
        Task<Ohs_Employee> GetEmployeeByIdAsync(Guid id);
        Task<Ohs_Employee?> GetUserByEmailAsync(string email);


    }
}