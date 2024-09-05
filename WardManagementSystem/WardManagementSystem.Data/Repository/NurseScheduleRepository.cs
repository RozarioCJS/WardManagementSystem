using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using WardManagementSystem.Data.Respository;

namespace WardManagementSystem.Data.Repository
{
    public class NurseScheduleRepository : INurseScheduleRepository
    {
        private readonly ISqlDataAccess _db;

        public NurseScheduleRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(NurseSchedule nurseSchedule)
        {
            try
            {
                await _db.SaveData("sp_add_nurse_schedule", nurseSchedule);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(NurseSchedule nurseSchedule)
        {
            try
            {
                await _db.SaveData("sp_update_nurse_schedule", nurseSchedule);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_delete_nurse_schedule", new { Id = id });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<NurseSchedule?> GetByIdAsync(int id)
        {
            var result = await _db.GetData<NurseSchedule, dynamic>("sp_get_nurse_schedule_by_id", new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<NurseSchedule>> GetAllAsync()
        {
            return await _db.GetData<NurseSchedule, object>("sp_get_all_nurse_schedules", new { });
        }
    }
}
