using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using isg_crm.Dtos;
using isg_crm.Models;
using isg_crm.Services;
using isg_crm.Interfaces;

namespace isg_crm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly IManagerInterface _managerRepository;
        private readonly IEmployeeInterface _employeeRepository;
        public AuthController(TokenService tokenService, IManagerInterface managerInterface, IEmployeeInterface employeeInterface)
        {
            _tokenService = tokenService;
            _managerRepository = managerInterface;
            _employeeRepository = employeeInterface;
        }
        [HttpPost("admin/login")]
        public async Task<IActionResult> Login([FromBody] LoginManagerDto loginDto)
        {
            var manager = await _managerRepository.GetUserByEmailAsync(loginDto.Email);

            if (manager == null || !PasswordHelper.VerifyPassword(loginDto.Password, manager.Password))
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            var managerId = manager.Id;
            var token = _tokenService.GenerateAdminToken(managerId, manager.Email, manager);

            var managerResponse = new
            {
                Id = manager.Id,
                Uuid = manager.Uuid,
                Email = manager.Email,
                Type = manager.Type,
                Name = manager.Name,
                CreatedAt = manager.CreatedAt,
                UpdatedAt = manager.UpdatedAt,

            };
            return Ok(new
            {
                Token = token,
                Manager = managerResponse
            });
        }
        [HttpPost("employee/login")]
        public async Task<IActionResult> EmployeeLogin([FromBody] LoginEmployeeDto loginEmployeeDto)
        {
            var employee = await _employeeRepository.GetUserByEmailAsync(loginEmployeeDto.Email);
            if (employee == null || !PasswordHelper.VerifyPassword(loginEmployeeDto.Password, employee.Password))
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }
            var employeeId = employee.Id;
            var token = _tokenService.GenerateEmployeeToken(employeeId, employee.Email);

            var employeeResponse = new
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
            };
            return Ok(new { Token = token, Employee = employeeResponse });
        }
    }
}