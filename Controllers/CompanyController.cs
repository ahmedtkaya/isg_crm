using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using isg_crm.Dtos;
using isg_crm.Interfaces;
using isg_crm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace isg_crm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyInterface _companyInterface;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CompanyController(ICompanyInterface companyInterface, IHttpContextAccessor httpContextAccessor)
        {
            _companyInterface = companyInterface;
            _httpContextAccessor = httpContextAccessor;

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCompany([FromForm] CreateCompanyDto createCompanyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var managerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (managerIdClaim == null)
            {
                return Unauthorized("Manager ID not found in claims.");
            }
            var managerId = Guid.Parse(managerIdClaim.Value);
            await _companyInterface.CreateCompanyAsync(managerId, createCompanyDto);
            return Ok("Company created successfully.");
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCompanyById(Guid id)
        {
            var company = await _companyInterface.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound("Company not found.");
            }
            return Ok(company);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _companyInterface.GetAllCompaniesAsync();
            if (companies == null || !companies.Any())
            {
                return NotFound("No companies found.");
            }
            return Ok(companies);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            try
            {
                var company = _companyInterface.DeleteCompanyAsync(id);
                if (company == null)
                {
                    return NotFound("Company Not Found.");
                }
                return Ok("Company deleted successfully.");
            }
            catch (System.Exception)
            {
                return BadRequest("An error occurred while deleting the company.");
            }
        }
    }
}