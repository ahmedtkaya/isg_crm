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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmployeeController(IEmployeeInterface employeeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _employeeRepository = employeeRepository;
        }

        [Authorize(Roles = "Admin,Super Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateEmployee([FromForm] CreateEmployeeDto createEmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var managerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (managerIdClaim == null)
            {
                return Unauthorized("User not found");
            }

            var managerId = Guid.Parse(managerIdClaim.Value);
            await _employeeRepository.CreateEmployeeAsync(managerId, createEmployeeDto);
            return Ok("Employee created successfully");
        }

        [Authorize(Roles = "Admin,Super Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid employee ID");
            }
            await _employeeRepository.DeleteEmployeeAsync(id);
            return Ok("Employee deleted successfully");
        }

        [Authorize(Roles = "Admin,Super Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employee = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employee);
        }

        [Authorize(Roles = "Admin,Super Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Employee not Found");
            }
            return Ok(employee);
        }

    }
}