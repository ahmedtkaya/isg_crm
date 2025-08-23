using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Data;
using isg_crm.Dtos;
using isg_crm.Interfaces;
using isg_crm.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Paddings;

namespace isg_crm.Repositories
{
    public class MissionRepository : IMissionInterface
    {
        private readonly AppDbContext _context;
        public MissionRepository(AppDbContext context)
        {
            _context = context;

        }
        public async Task CreateMissionAsync(Guid employeeId, CreateMissionDto createMissionDto)
        {
            var mission = new Mission
            {
                Description = createMissionDto.Description,
                ToGoDate = createMissionDto.ToGoDate,
                Status = (MissionStatus)StatusType.Pending,
                AssignId = createMissionDto.AssignId,
                EmployeeId = employeeId
            };
            await _context.Missions.AddAsync(mission);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Mission>> GetAllMissions()
        {
            return await _context.Missions.ToListAsync();
        }

        public async Task<IEnumerable<Mission>> GetMissionsByEmployeeId(Guid employeeId)
        {
            return await _context.Missions.Where(a => a.EmployeeId == employeeId).Include(a => a.Assign).ToListAsync();

        }
        public async Task<List<Mission>> GetStatusPendingMissionsByEmployeeId(Guid employeeId)
        {
            return await _context.Missions.Where(a => a.EmployeeId == employeeId && a.Status == MissionStatus.Pending).ToListAsync();
        }
        public async Task<List<Mission>> GetStatusToGoMissionsByEmployeeId(Guid employeeId)
        {
            return await _context.Missions.Where(a => a.EmployeeId == employeeId && a.Status == MissionStatus.ToGo).ToListAsync();
        }
        public async Task<List<Mission>> GetStatusCompletedMissionsByEmployeeId(Guid employeeId)
        {
            return await _context.Missions.Where(a => a.EmployeeId == employeeId && a.Status == MissionStatus.Completed).ToListAsync();
        }

        public async Task MarkMissionAsCompletedAsync(Guid missionId)
        {
            var mission = await _context.Missions.FindAsync(missionId);
            if (mission != null)
            {
                mission.Status = MissionStatus.Completed;
                await _context.SaveChangesAsync();
            }
        }
        public async Task MarkMissionAsToGoAsync(Guid missionId)
        {
            var mission = await _context.Missions.FindAsync(missionId);
            if (mission != null)
            {
                mission.Status = MissionStatus.ToGo;
                await _context.SaveChangesAsync();
            }
        }

        public Task DeleteMission(Guid missionId)
        {
            var mission = _context.Missions.Find(missionId);
            if (mission == null)
            {
                throw new KeyNotFoundException("Company Not Found.");
            }
            _context.Missions.Remove(mission);
            return _context.SaveChangesAsync();
        }


    }
}