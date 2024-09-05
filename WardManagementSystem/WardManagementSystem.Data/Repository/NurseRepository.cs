using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Respository;



namespace WardManagementSystem.Data.Repository
{
    public class NurseRepository : INurseRepository
    {
        private readonly ISqlDataAccess _db;
        public NurseRepository(ISqlDataAccess db) 
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Nurse nurse)
        {
            try
            {
                await _db.SaveData("sp_create_nurse", new { nurse.FirstName, nurse.LastName, nurse.PhoneNumber, nurse.Email });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Nurse nurse)
        {
            try
            {
                await _db.SaveData("sp_update_nurse", nurse);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_delete_nurse", new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Nurse?> GetByIdAsync(int id)
        {
            IEnumerable<Nurse> result = await _db.GetData<Nurse, dynamic>("sp_get_nurse", new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Nurse>> GetAllAsync()
        {
            string query = "sp_get_nurses";
            return await _db.GetData<Nurse, dynamic>(query, new { });
        }
    }
}
