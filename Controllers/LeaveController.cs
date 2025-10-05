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

    public class LeaveController : ControllerBase
    {
        private readonly ILeaveInterface _leaveRepository;
        public LeaveController(ILeaveInterface leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }
        [Authorize(Roles = "Admin,Super Admin,Manager")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateLeave([FromBody] CreateLeaveDto createLeaveDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var leave = await _leaveRepository.CreateLeaveAsync(createLeaveDto);
            return Ok(new { message = "Leave created successfully", leave });
        }

        [Authorize(Roles = "Admin,Super Admin,Manager")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteLeave(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid leave ID");

            await _leaveRepository.DeleteLeaveAsync(id);
            return Ok(new { message = "Leave deleted successfully" });
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Super Admin,Manager")]
        public async Task<ActionResult> GetAllLeave()
        {
            var leave = await _leaveRepository.GetAllLeavesAsync();
            return Ok(leave);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Super Admin,Manager")]
        public async Task<ActionResult> GetLeaveById(Guid id)
        {
            var leave = await _leaveRepository.GetLeaveByIdAsync(id);
            if (leave == null)
                return NotFound("Leave not found");

            return Ok(leave);
        }

        [HttpGet("employee/{employeeId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetLeavesByEmployeeId(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
                return BadRequest("Invalid employee ID");

            var leaves = await _leaveRepository.GetByLeaveFromEmployeeId(employeeId);

            if (leaves == null || !leaves.Any())
                return NotFound("No leaves found for this employee");

            return Ok(leaves);
        }


    }
}