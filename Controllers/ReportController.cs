using System.Security.Claims;
using isg_crm.Dtos;
using isg_crm.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace isg_crm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportInterface _reportInterface;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReportController(IReportInterface reportInterface, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _reportInterface = reportInterface;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateReport([FromForm] CreateReportDto createReportDto, IFormFile fileUrl)
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
            await _reportInterface.CreateReportAsync(employeeId, createReportDto, fileUrl);
            return Ok("Report Create Successfully");
        }

        [HttpGet("by-report-id")]
        [Authorize]
        public async Task<IActionResult> GetReportById([FromQuery] Guid id)//FromQuery id= olarak alır
        {
            var report = await _reportInterface.GetReportByIdAsync(id);
            if (report == null)
            {
                return NotFound("Report Not Found");
            }
            return Ok(report);
        }

        [HttpGet("my-reports")]
        [Authorize]
        public async Task<IActionResult> GetReportsByEmployee()
        {
            var employeeIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (employeeIdClaim == null)
                return Unauthorized();

            var employeeId = Guid.Parse(employeeIdClaim);
            var assigns = await _reportInterface.GetReportsByEmployeeIdAsync(employeeId);
            return Ok(assigns);
        }

        [HttpGet("sort-by-company")]
        [Authorize]
        public async Task<IActionResult> GetReportsByCompanyId([FromQuery] Guid companyId)
        {
            var report = await _reportInterface.GetReportsByCompanyAsync(companyId);
            if (report == null)
            {
                return NotFound("Report Not Found By This Company ID");
            }
            return Ok(report);
        }
        [HttpGet("download/{id}")]
        [Authorize] //[Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> DownloadReport(Guid id)
        {
            var result = await _reportInterface.DownloadReportAsync(id, User);
            if (result == null) return NotFound("Report not found or file missing");
            return result;
        }

    }
}