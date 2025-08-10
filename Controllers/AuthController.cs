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
        public AuthController(TokenService tokenService, IManagerInterface managerInterface)
        {
            _tokenService = tokenService;
            _managerRepository = managerInterface;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginManagerDto loginDto)
        {
            var manager = await _managerRepository.GetUserByEmailAsync(loginDto.Email);

            if (manager == null || !PasswordHelper.VerifyPassword(loginDto.Password, manager.Password))
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            var managerId = manager.Id;
            var token = _tokenService.GenerateToken(managerId, manager.Email);

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
    }
}