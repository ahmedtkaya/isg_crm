using System;
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


        // [Authorize(Roles = "Employee,Admin,Manager,Super Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateLeave([FromBody] CreateLeaveDto createLeaveDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 🔑 Token içinden kullanıcı ID'sini al
            var employeeIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                  ?? User.FindFirst("nameid")?.Value
                                  ?? User.FindFirst("id")?.Value;

            if (employeeIdClaim == null)
                return Unauthorized("Kullanıcı kimliği bulunamadı.");

            var employeeId = Guid.Parse(employeeIdClaim);

            // Çalışanın kendi ID’sini DTO’ya set et
            createLeaveDto.EmployeeId = employeeId;

            var leave = await _leaveRepository.CreateLeaveAsync(createLeaveDto);
            return Ok(new { message = "İzin talebi başarıyla oluşturuldu.", leave });
        }



        [Authorize(Roles = "Admin,Manager,Super Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllLeaves()
        {
            var leaves = await _leaveRepository.GetAllLeavesAsync();
            return Ok(leaves);
        }

        // [Authorize(Roles = "Employee,Admin,Manager,Super Admin")]
        [HttpGet("my-leaves")]
        public async Task<IActionResult> GetMyLeaves()
        {
            var employeeIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                                  ?? User.FindFirst("nameid")?.Value
                                  ?? User.FindFirst("id")?.Value;

            if (employeeIdClaim == null)
                return Unauthorized("Kullanıcı kimliği bulunamadı.");

            var employeeId = Guid.Parse(employeeIdClaim);
            var leaves = await _leaveRepository.GetByLeaveFromEmployeeId(employeeId);

            return Ok(leaves);
        }

        [Authorize(Roles = "Admin,Manager,Super Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeaveById(Guid id)
        {
            var leave = await _leaveRepository.GetLeaveByIdAsync(id);
            if (leave == null)
                return NotFound("İzin kaydı bulunamadı.");
            return Ok(leave);
        }


        [Authorize(Roles = "Admin,Manager,Super Admin")]
        [HttpPut("update-status/{id}")]
        public async Task<IActionResult> UpdateLeaveStatus(Guid id, [FromBody] UpdateLeaveStatusDto dto)
        {
            var updated = await _leaveRepository.UpdateLeaveStatusAsync(id, dto.Status); //buradan devam et
            if (!updated)
                return NotFound("İzin kaydı bulunamadı.");
            return Ok(new { message = "İzin durumu güncellendi." });
        }

        [Authorize(Roles = "Admin,Manager,Super Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeave(Guid id)
        {
            await _leaveRepository.DeleteLeaveAsync(id);
            return Ok(new { message = "İzin kaydı silindi." });
        }
        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateLeave([FromQuery] Guid id, [FromBody] UpdateLeaveDto updateLeaveDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _leaveRepository.UpdateLeaveAsync(id, updateLeaveDto);
            if (!result)
            {
                return NotFound("İzin kaydı bulunamadı.");
            }
            return Ok(new { message = "İzin kaydı güncellendi." });
        }
    }
}
