using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Models;
using isg_crm.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace isg_crm.Interfaces
{
    public interface IReportInterface
    {
        Task CreateReportAsync(Guid employeeId, CreateReportDto createReportDto, IFormFile fileUrl);
        Task<Report> GetReportByIdAsync(Guid id);
        Task<IEnumerable<Report>> GetReportsByCompanyAsync(Guid companyId);
        Task<IEnumerable<Report>> GetReportsByEmployeeIdAsync(Guid employeeId);
        Task DeleteReportAsync(Guid id);

        Task<FileStreamResult?> DownloadReportAsync(Guid id, ClaimsPrincipal user);
    }
}