using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Interfaces;
using isg_crm.Data;
using isg_crm.Models;
using isg_crm.Dtos;
using Microsoft.EntityFrameworkCore;


namespace isg_crm.Repositories
{
    public class LeaveRepository : ILeaveInterface
    {
        private readonly AppDbContext _context;

        public LeaveRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Leave> CreateLeaveAsync(CreateLeaveDto createLeaveDto)
        {
            var leave = new Leave
            {
                Id = Guid.NewGuid(),
                StartDay = DateTime.SpecifyKind(createLeaveDto.StartDay, DateTimeKind.Utc),
                EndDay = DateTime.SpecifyKind(createLeaveDto.EndDay, DateTimeKind.Utc),
                EmployeeId = createLeaveDto.EmployeeId,
                Description = createLeaveDto.Description,
                LeaveType = createLeaveDto.LeaveType,
                Status = createLeaveDto.Status
            };
            await _context.Leaves.AddAsync(leave);
            await _context.SaveChangesAsync();

            return (leave);
        }

        public async Task<IEnumerable<Leave>> GetAllLeavesAsync()
        {
            return await _context.Leaves.ToListAsync();
        }

        public async Task<Leave?> GetLeaveByIdAsync(Guid id)
        {
            return await _context.Leaves.FirstOrDefaultAsync(l => l.Id == id);
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

        public async Task<IEnumerable<Leave>> GetByLeaveFromEmployeeId(Guid employeeId)
        {
            return await _context.Leaves
            .Where(a => a.EmployeeId == employeeId).Include(a => a.EmployeeId)
            .ToListAsync();
        }
    }
}