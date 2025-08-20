using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using isg_crm.Data;
using isg_crm.Dtos;
using isg_crm.Interfaces;
using isg_crm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace isg_crm.Repositories
{
    public class ReportRepository : IReportInterface
    {
        private readonly AppDbContext _context;


        public ReportRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task CreateReportAsync(Guid employeeId, CreateReportDto createReportDto, IFormFile fileUrl)
        {
            var report = new Report
            {
                ReportDescription = createReportDto.ReportDescription,
                ReportType = createReportDto.ReportType,
                CompanyId = createReportDto.CompanyId,
                ControlCheck = createReportDto.ControlCheck,
                EmployeeId = employeeId
            };
            // if (fileUrl != null)
            // {
            //     var fileExtension = Path.GetExtension(fileUrl.FileName);
            //     if (fileExtension != ".pdf")
            //     {
            //         throw new Exception("Invalid file type. Only .pdf");
            //     }
            //     var fileName = $"{report.CompanyId}{Path.GetExtension(fileUrl.FileName)}";
            //     var filePath = Path.Combine($"public/reports/{employeeId}", fileName);
            //     using (var stream = new FileStream(filePath, FileMode.Create))
            //     {
            //         await fileUrl.CopyToAsync(stream);
            //     }
            //     report.ReportFileUrl = filePath;
            // }
            if (fileUrl != null)
            {
                var fileExtension = Path.GetExtension(fileUrl.FileName).ToLowerInvariant();
                if (fileExtension != ".pdf")
                {
                    throw new Exception("Invalid file type. Only .pdf files are allowed.");
                }

                // 🔹 Company + Tarih klasör yapısı
                var companyFolder = Path.Combine("public", "reports", report.CompanyId.ToString());
                var dateFolder = DateTime.UtcNow.ToString("yyyy-MM-dd"); // örn. 20250819
                var fullFolderPath = Path.Combine(companyFolder, dateFolder);
                Directory.CreateDirectory(fullFolderPath);


                using var sha256 = SHA256.Create();
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));
                var hashName = Convert.ToHexString(hashBytes).ToLower();

                var hashedFileName = $"{hashName}{fileExtension}";
                Console.WriteLine("hashlenmiş file name = ", hashedFileName);

                var filePath = Path.Combine(fullFolderPath, hashedFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUrl.CopyToAsync(stream);
                }

                // DB'ye URL olarak kaydet
                report.ReportFileUrl = Path.Combine("reports", report.CompanyId.ToString(), dateFolder, hashedFileName);
            }
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
        }
        public async Task<Report> GetReportByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid company ID.", nameof(id));
            }
            return await _context.Reports.FindAsync(id);
        }

        public async Task<IEnumerable<Report>> GetReportsByEmployeeIdAsync(Guid employeeId)
        {
            return await _context.Reports
                                 .Where(a => a.EmployeeId == employeeId)//Include bu veri seti içerisindeki companyId verilerinide göster demek oluyor.
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsByCompanyAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentException("Invalid company ID.", nameof(companyId));
            }
            return await _context.Reports
                         .Where(r => r.CompanyId == companyId)
                         .ToListAsync();
        }
        public Task DeleteReportAsync(Guid id)
        {
            var report = _context.Reports.Find(id);
            if (report == null)
            {
                throw new KeyNotFoundException("Company Not Found.");
            }
            _context.Reports.Remove(report);
            return _context.SaveChangesAsync();
        }
        public async Task<FileStreamResult?> DownloadReportAsync(Guid reportId, ClaimsPrincipal user)
        {
            var report = await _context.Reports.FindAsync(reportId);
            if (report == null) return null;

            // // 🔹 Rol kontrolü (sadece Admin ve SuperAdmin)
            // if (!user.IsInRole("Admin") && !user.IsInRole("SuperAdmin"))
            //     throw new UnauthorizedAccessException("You are not allowed to download this report.");

            var filePath = Path.Combine("public", report.ReportFileUrl);
            if (!File.Exists(filePath))
                return null;

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return new FileStreamResult(memory, "application/pdf")
            {
                FileDownloadName = $"{report.ReportType}.pdf"
            };
        }

    }
}