using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Repository;
using WardManagementSystem.Data.Models.ViewModels;

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
                await _db.SaveData("sp_CreateScript", new { script.DoctorID, script.PatientFileID, script.MedicationID, script.Dosage });          // Date to current date and Status field will be to 'N' in stored procedure
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
                await _db.SaveData("sp_UpdateScript", new { script.ScriptID, script.MedicationID, script.Dosage });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<DoctorFullNameViewModel>> GetDoctorFullNameAsync()
        {
            var query = "sp_DoctorFullName";
            return await _db.GetData<DoctorFullNameViewModel, dynamic>(query, new { });
        }

        public async Task<IEnumerable<PatientFileFullNameViewModel>> GetPatientFullNameAsync()
        {
            var query = "sp_PatientFullName_PatientFile";
            return await _db.GetData<PatientFileFullNameViewModel, dynamic>(query, new { });
        }

        public async Task<IEnumerable<MedicationNameViewModel>> GetMedicationNameAsync()
        {
            var query = "sp_DisplayMedicationName";
            return await _db.GetData<MedicationNameViewModel, dynamic>(query, new { });
        }

        public async Task<IEnumerable<PatientScriptViewModel>> GetAllPatientAsync(int PatientFileID)      //still have to code it in a way that uses DoctorID to only display specif doctor's schedule. Code to be updated in stored procedure as well!!
        {
            string query = "sp_PatientScriptVM";
            return await _db.GetData<PatientScriptViewModel, dynamic>(query, new { PatientFileID = PatientFileID });
        }
    }
}
