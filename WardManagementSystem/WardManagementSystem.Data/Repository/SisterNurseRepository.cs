using WardManagementSystem.Data.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using WardManagementSystem.Data.DataAccess;

namespace WardManagementSystem.Data.Repository
{
    public class SisterNurseRepository : ISisterNurseRepository
    {
        private readonly ISqlDataAccess _db;

        public SisterNurseRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(SisterNurse sisterNurse)
        {
            try
            {
                await _db.SaveData("sp_add_sister_nurse", sisterNurse);
                return true; // Assume the operation succeeded
            }
            catch
            {
                return false; // Operation failed
            }
        }

        public async Task<bool> UpdateAsync(SisterNurse sisterNurse)
        {
            try
            {
                await _db.SaveData("sp_update_sister_nurse", sisterNurse);
                return true; // Assume the operation succeeded
            }
            catch
            {
                return false; // Operation failed
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_delete_sister_nurse", new { Id = id });
                return true; // Assume the operation succeeded
            }
            catch
            {
                return false; // Operation failed
            }
        }

        public async Task<SisterNurse?> GetByIdAsync(int id)
        {
            IEnumerable<SisterNurse> result = await _db.GetData<SisterNurse, dynamic>("sp_get_sister_nurse_by_id", new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<SisterNurse>> GetAllAsync()
        {
            string query = "sp_get_sister_nurses";
            return await _db.GetData<SisterNurse, dynamic>(query, new { });
        }
    }
}
