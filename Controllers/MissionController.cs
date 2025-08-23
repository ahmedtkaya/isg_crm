using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using isg_crm.Dtos;
using isg_crm.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace isg_crm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionController : ControllerBase
    {
        private readonly IMissionInterface _missionInterface;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MissionController(IMissionInterface missionInterface, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _missionInterface = missionInterface;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateMission([FromBody] CreateMissionDto createMissionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Unauthorized("User not found");
            }
            var employeeId = Guid.Parse(userIdClaim.Value);
            await _missionInterface.CreateMissionAsync(employeeId, createMissionDto);
            return Ok("Mission Create Successfully");
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Super Admin")]
        public async Task<IActionResult> GetAllMissions()
        {
            var missions = await _missionInterface.GetAllMissions();
            if (missions == null || !missions.Any())
            {
                return NotFound("No missions found");
            }
            return Ok(missions);
        }

        [HttpGet("my-missions")]
        [Authorize]
        public async Task<IActionResult> GetMyMissions()
        {
            var employeeIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (employeeIdClaim == null)
                return Unauthorized();

            var employeeId = Guid.Parse(employeeIdClaim);
            var missions = await _missionInterface.GetMissionsByEmployeeId(employeeId);
            if (missions == null || !missions.Any())
            {
                return NotFound("There is no any mission for authorized employee");
            }
            return Ok(missions);
        }

        [HttpGet("status/pending")]
        [Authorize]
        public async Task<IActionResult> GetPendingMissions()
        {
            var employeeIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (employeeIdClaim == null)
                return Unauthorized();

            var employeeId = Guid.Parse(employeeIdClaim);
            var missions = await _missionInterface.GetStatusPendingMissionsByEmployeeId(employeeId);
            if (missions == null || !missions.Any())
            {
                return NotFound("No completed missions found.");
            }
            return Ok(missions);
        }

        [HttpGet("status/to-go")]
        [Authorize]
        public async Task<IActionResult> GetToGoMissions()
        {
            var employeeIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (employeeIdClaim == null)
                return Unauthorized();

            var employeeId = Guid.Parse(employeeIdClaim);
            var missions = await _missionInterface.GetStatusToGoMissionsByEmployeeId(employeeId);
            if (missions == null || !missions.Any())
            {
                return NotFound("No completed missions found.");
            }
            return Ok(missions);
        }

        [HttpGet("status/completed")]
        [Authorize]
        public async Task<IActionResult> GetCompletedMissions()
        {
            var employeeIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (employeeIdClaim == null)
                return Unauthorized();

            var employeeId = Guid.Parse(employeeIdClaim);
            var missions = await _missionInterface.GetStatusCompletedMissionsByEmployeeId(employeeId);
            if (missions == null || !missions.Any())
            {
                return NotFound("No completed missions found.");
            }
            return Ok(missions);
        }

        [HttpPut("{missionId}/complete")]
        [Authorize]
        public async Task<IActionResult> MarkMissionAsCompleted(Guid missionId)
        {
            await _missionInterface.MarkMissionAsCompletedAsync(missionId);
            return Ok("Mission marked as completed.");
        }
        [HttpPut("{missionId}/to-go")]
        [Authorize]
        public async Task<IActionResult> MarkToGoAsCompleted(Guid missionId)
        {
            await _missionInterface.MarkMissionAsToGoAsync(missionId);
            return Ok("Mission marked as completed.");
        }

        [HttpDelete("delete/{missionId}")]
        [Authorize]
        public async Task<IActionResult> DeleteMission(Guid missionId)
        {
            try
            {
                var mission = _missionInterface.DeleteMission(missionId);
                if (mission == null)
                {
                    return NotFound($"{missionId} ID mission is not found");
                }
                return Ok("Assign deleted successfully");
            }
            catch (System.Exception)
            {
                return BadRequest("An error occurred while deleting the company.");
            }
        }
    }
}