using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Interfaces;
using isg_crm.Models;
using isg_crm.Dtos;
using isg_crm.Data;
using Microsoft.EntityFrameworkCore;
using MailKit.Net.Smtp;
using MimeKit;


namespace isg_crm.Repositories
{
    public class AssignRepository : IAssignInterface
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        public AssignRepository(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<Guid> CreateAssignAsync(Guid employeeId, Guid companyId, CreateAssignDto createAssignDto)
        {
            // Company bilgilerini al
            var company = await _context.Company
                .FirstOrDefaultAsync(c => c.Id == createAssignDto.CompanyId);
            if (company == null)
            {
                throw new Exception("Company not found.");
            }

            // Employee bilgilerini al
            var employee = await _context.Ohs_Employees
                .FirstOrDefaultAsync(e => e.Id == createAssignDto.EmployeeId);
            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            if (company != null)
            {
                Console.WriteLine("---- COMPANY ----");
                Console.WriteLine($"Id: {company.Id}");
                Console.WriteLine($"Name: {company.CompanyName}");
                Console.WriteLine($"Address: {company.CompanyAddress}");
                // diğer alanlar...
            }

            if (employee != null)
            {
                Console.WriteLine("---- EMPLOYEE ----");
                Console.WriteLine($"Id: {employee.Id}");
                Console.WriteLine($"FirstName: {employee.Name}");
                Console.WriteLine($"Email: {employee.Email}");
                // diğer alanlar...
            }
            var assign = new Assignees
            {
                Description = createAssignDto.Description,
                EmployeeId = createAssignDto.EmployeeId,
                CompanyId = createAssignDto.CompanyId,
            };

            await _context.Assignees.AddAsync(assign);
            await _context.SaveChangesAsync();
            await _emailService.SendAssignEmailAsync(employee.Email, company.CompanyName, company.CompanyAddress, employee.Name, assign.Description);
            return assign.Id; // Return the ID of the created assign

        }

        public async Task<IEnumerable<Assignees>> GetAllAssignsAsync()
        {
            return await _context.Assignees.ToListAsync();
        }
        public Task DeleteAssignAsync(Guid id)
        {
            var assign = _context.Assignees.Find(id); //Tekil idye sahip assign verisini getirdik.
            if (assign == null)
            {
                throw new KeyNotFoundException("Assign not found.");
            }
            _context.Assignees.Remove(assign); //üstteki getirdiğim idyi sildik
            return _context.SaveChangesAsync();
        }

    }
}