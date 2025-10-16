using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Interfaces;
using isg_crm.Models;
using isg_crm.Dtos;
using isg_crm.Data;
using Microsoft.EntityFrameworkCore;

namespace isg_crm.Repositories
{
    public class CompanyRepository : ICompanyInterface
    {
        private readonly AppDbContext _context;
        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCompanyAsync(Guid managerId, CreateCompanyDto createCompanyDto)
        {

            try
            {
                var company = new Company
                {
                    CompanyName = createCompanyDto.CompanyName,
                    CompanyAddress = createCompanyDto.CompanyAddress,
                    CompanyPhone = createCompanyDto.CompanyPhone,
                    CompanyEmail = createCompanyDto.CompanyEmail,
                    CompanyTaxNumber = createCompanyDto.CompanyTaxNumber,
                    ManagerId = managerId,
                };

                await _context.Company.AddAsync(company);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception("An error occurred while creating the company.", ex);
            }
        }



        public async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid company ID.", nameof(id));
            }
            return await _context.Company.FindAsync(id);
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _context.Company.ToListAsync();
        }

        public Task DeleteCompanyAsync(Guid id)
        {
            var company = _context.Company.Find(id);
            if (company == null)
            {
                throw new KeyNotFoundException("Company not found.");
            }
            _context.Company.Remove(company);
            return _context.SaveChangesAsync();
        }
        public async Task UpdateCompanyAsync(Guid id, UpdateCompanyDto updateCompanyDto)
        {
            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                throw new KeyNotFoundException("Company not found.");
            }

            company.CompanyName = updateCompanyDto.CompanyName;
            company.CompanyAddress = updateCompanyDto.CompanyAddress;
            company.CompanyPhone = updateCompanyDto.CompanyPhone;
            company.CompanyEmail = updateCompanyDto.CompanyEmail;
            company.CompanyTaxNumber = updateCompanyDto.CompanyTaxNumber;
            company.WarningClass = updateCompanyDto.WarningClass;
            company.UpdatedAt = DateTime.UtcNow;

            _context.Company.Update(company);
            await _context.SaveChangesAsync();
        }
    }
}