using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Dtos;
using isg_crm.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace isg_crm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerInterface _managerRepository;
        public ManagerController(IManagerInterface managerRepository)
        {
            _managerRepository = managerRepository;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin,Super Admin")]
        public async Task<IActionResult> CreateManager([FromBody] CreateManagerDto createManagerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isEmailRegistered = await _managerRepository.IsEmailRegisteredAsync(createManagerDto.Email);
            if (isEmailRegistered)
            {
                return Conflict("Email is already registered.");
            }

            var managerId = Guid.NewGuid();
            await _managerRepository.CreateManagerAsync(managerId, createManagerDto);
            return Ok("Manager created successfully");
        }

    }
}