using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using isg_crm.Data;
using isg_crm.Dtos;
using isg_crm.Interfaces;
using isg_crm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace isg_crm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignController : ControllerBase
    {
        private readonly IAssignInterface _assignInterface;
        // private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _context;

        public AssignController(IAssignInterface assignInterface, AppDbContext context)
        {
            _assignInterface = assignInterface;
            // _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAssign([FromBody] CreateAssignDto createAssignDto)
        {
            if (createAssignDto == null)
            {
                return BadRequest("Assign data is required.");
            }

            var assign = await _assignInterface.CreateAssignAsync(createAssignDto.CompanyId, createAssignDto.EmployeeId, createAssignDto);
            // Company verisini getir
            var company = await _context.Company
                .FirstOrDefaultAsync(c => c.Id == createAssignDto.CompanyId);

            // Employee verisini getir
            var employee = await _context.Ohs_Employees
                .FirstOrDefaultAsync(e => e.Id == createAssignDto.EmployeeId);
            return Ok(new { Message = "Assign created successfully.", Id = assign, Company = company, Employee = employee });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAssignees()
        {
            try
            {
                var assign = await _assignInterface.GetAllAssignsAsync();
                if (assign == null || !assign.Any())
                {
                    return NotFound("No Assign Found.");
                }
                return Ok(assign);
            }
            catch (System.Exception)
            {

                return BadRequest("An Error occured while get all assignees");
            }
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAssign(Guid id)
        {
            try
            {
                var assign = _assignInterface.DeleteAssignAsync(id);
                if (assign == null)
                {
                    return NotFound("Assign No Found");
                }
                return Ok("Assign deleted successfully");
            }
            catch (System.Exception)
            {
                return BadRequest("An error occurred while deleting the company.");
            }
        }

        [HttpGet("my-assign")]
        [Authorize] // JWT authentication gerekli
        public async Task<IActionResult> GetMyAssigns()
        {
            var employeeIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (employeeIdClaim == null)
                return Unauthorized();

            var employeeId = Guid.Parse(employeeIdClaim);
            var assigns = await _assignInterface.GetByAssignFromEmployeeId(employeeId);
            return Ok(assigns);
        }

        [Authorize]
        [HttpPut("{id}/accepted")]
        public async Task<IActionResult> UpdateStatus(Guid id)
        {
            var employeeIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (employeeIdClaim == null)
            {
                return Unauthorized();
            }
            var employeeId = Guid.Parse(employeeIdClaim);

            var assign = await _assignInterface.GetAssignByIdAsync(id);
            if (assign == null)
            {
                return BadRequest("There is no assign or you have no permission.");
            }

            assign.Status = StatusType.Accepted;
            await _assignInterface.UpdateAsync(assign);

            return Ok(new { message = "Mark as Accepted this assign" });
        }

    }
}
