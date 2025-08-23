using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Dtos;
using isg_crm.Models;

namespace isg_crm.Interfaces
{
    public interface IMissionInterface
    {
        Task CreateMissionAsync(Guid employeeId, CreateMissionDto createMissionDto);
        Task<IEnumerable<Mission>> GetAllMissions();
        Task<IEnumerable<Mission>> GetMissionsByEmployeeId(Guid employeeId);
        Task<List<Mission>> GetStatusPendingMissionsByEmployeeId(Guid employeeId);
        Task<List<Mission>> GetStatusCompletedMissionsByEmployeeId(Guid employeeId);
        Task<List<Mission>> GetStatusToGoMissionsByEmployeeId(Guid employeeId);
        Task MarkMissionAsCompletedAsync(Guid missionId);
        Task MarkMissionAsToGoAsync(Guid missionId);
        Task DeleteMission(Guid missionId);
    }
}