using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Interfaces;
using isg_crm.Data;
using isg_crm.Models;
using isg_crm.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using isg_crm.Services;

namespace isg_crm.Repositories
{
    public class EmployeeRepository : IEmployeeInterface
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public EmployeeRepository(AppDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;

        }

        public async Task CreateEmployeeAsync(Guid managerId, CreateEmployeeDto employeeDto)
        {
            var generatedPassword = PasswordGenerator.GeneratePassword();
            Console.WriteLine($"Generated Password: {generatedPassword}");
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(generatedPassword);
            var employee = new Ohs_Employee
            {
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                Password = hashedPassword,
                IdentityNumber = employeeDto.IdentityNumber,
                Mission = employeeDto.Mission,
                CertificateNumber = employeeDto.CertificateNumber,
                CertificateDate = employeeDto.CertificateDate,

            };
            await _context.Ohs_Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            await _emailService.SendPasswordEmailAsync(employee.Email, generatedPassword);
        }
        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Ohs_Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Ohs_Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Ohs_Employee> GetEmployeeByIdAsync(Guid id)
        {
            return await _context.Ohs_Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Ohs_Employee>> GetAllEmployeesAsync()
        {
            return await _context.Ohs_Employees.ToListAsync();
        }
        public async Task<Ohs_Employee> GetUserByEmailAsync(string email)
        {
            return await _context.Ohs_Employees.FirstOrDefaultAsync(u => u.Email == email);
        }


    }

}