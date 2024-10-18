using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{


    public class PatientFolderRepository : IPatientFolderRepository
    {
        private readonly ISqlDataAccess _db;

        public PatientFolderRepository(ISqlDataAccess db)
        {
            _db = db;
        }
      
        public async Task<bool> AddPatientFolderAsync(PatientFolder patientfolder)
        {

            try
            {
                await _db.SaveData("sp_AddPatientFolder", new { patientfolder });
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeletePatientFolderAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_DeletePatientFolder", new { PatientFileID = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<PatientFolder>> GetAllPatientFolderAsync()
        {
            string query = "sp_GetPatientFolder";
            return await _db.GetData<PatientFolder, dynamic>(query, new { });
        }

        public async Task<PatientFolder> GetPatientFolderByIdAsync(int id)
        {
            IEnumerable<PatientFolder> result = await _db.GetData<PatientFolder, dynamic>("sp_GetPatientFolder", new { PatientFileID = id });
            return result.FirstOrDefault();
        }

        public Task GetPatientFolderByIdAsync(string firstName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePatientFolderAsync(PatientFolder patientfolder)
        {
            try
            {

                await _db.SaveData("sp_UpdatePatientFolder", patientfolder);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
