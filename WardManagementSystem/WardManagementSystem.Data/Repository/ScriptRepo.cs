using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Data.Repository
{
    public class ScriptRepo : IScriptRepo
    {
        private readonly ISqlDataAccess _db;
        public ScriptRepo(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Script script)
        {
            try
            {
                await _db.SaveData("sp_CreateScript", new { script.DoctorID, script.PatientFileID, script.MedicationID, script.Date, script.Dosage });          // Status field Will be added in stored procedure to 'N'
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
                await _db.SaveData("sp_DeleteScript", new { ScriptID = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Script>> GetAllAsync()
        {
            string query = "sp_ViewAllScripts";
            return await _db.GetData<Script, dynamic>(query, new { });
        }

        public async Task<Script> GetByIdAsync(int id)
        {
            IEnumerable<Script> result = await _db.GetData<Script, dynamic>("sp_FindScript", new { ScriptID = id });
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(Script script)
        {
            try
            {
                await _db.SaveData("sp_UpdateScript", script);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
