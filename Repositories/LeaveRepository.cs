using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Data;
using isg_crm.Dtos;
using isg_crm.Interfaces;
using isg_crm.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1;

namespace isg_crm.Repositories
{
    public class LeaveRepository : ILeaveInterface
    {
        private readonly AppDbContext _context;

        public LeaveRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Leave> CreateLeaveAsync(CreateLeaveDto dto)
        {
            var leave = new Leave
            {
                Id = Guid.NewGuid(),
                StartDay = DateTime.SpecifyKind(dto.StartDay, DateTimeKind.Utc),
                EndDay = DateTime.SpecifyKind(dto.EndDay, DateTimeKind.Utc),
                EmployeeId = dto.EmployeeId,
                Description = dto.Description,
                LeaveType = dto.LeaveType,
                Status = ApproveStatus.Pending, // 🔒 her yeni izin talebi "Pending" başlar
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Leaves.AddAsync(leave);
            await _context.SaveChangesAsync();
            return leave;
        }

        public async Task<IEnumerable<Leave>> GetAllLeavesAsync()
        {
            return await _context.Leaves.Include(l => l.Employee).ToListAsync();
        }

        public async Task<Leave?> GetLeaveByIdAsync(Guid id)
        {
            return await _context.Leaves.Include(l => l.Employee).FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Leave>> GetByLeaveFromEmployeeId(Guid employeeId)
        {
            return await _context.Leaves
                .Where(l => l.EmployeeId == employeeId)
                .Include(l => l.Employee)
                .ToListAsync();
        }

        public async Task<bool> UpdateLeaveStatusAsync(Guid id, ApproveStatus status)
        {
            var leave = await _context.Leaves.FirstOrDefaultAsync(l => l.Id == id);
            if (leave == null) return false;

            leave.Status = status;
            leave.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteLeaveAsync(Guid id)
        {
            var leave = await _context.Leaves.FindAsync(id);
            if (leave != null)
            {
                _context.Leaves.Remove(leave);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateLeaveAsync(Guid id, UpdateLeaveDto updateLeaveDto)
        {
            var leave = await _context.Leaves.FirstOrDefaultAsync(l => l.Id == id);
            if (leave == null) return false;

            leave.StartDay = DateTime.SpecifyKind(updateLeaveDto.StartDay, DateTimeKind.Utc);
            leave.EndDay = DateTime.SpecifyKind(updateLeaveDto.EndDay, DateTimeKind.Utc);
            leave.Description = updateLeaveDto.Description;
            leave.LeaveType = updateLeaveDto.LeaveType;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
