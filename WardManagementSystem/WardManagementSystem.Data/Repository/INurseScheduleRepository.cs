using WardManagementSystem.Data.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Respository
{
    public interface INurseScheduleRepository
    {
        Task<bool> AddAsync(NurseSchedule nurseSchedule);
        Task<bool> UpdateAsync(NurseSchedule nurseSchedule);
        Task<bool> DeleteAsync(int id);
        Task<NurseSchedule?> GetByIdAsync(int id);
        Task<IEnumerable<NurseSchedule>> GetAllAsync();
    }
}
