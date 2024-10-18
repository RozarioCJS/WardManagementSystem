using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Repository;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ISqlDataAccess _db;

        public PatientRepository(ISqlDataAccess db)
        {
            _db = db;
        }
        public async Task<bool> AddPatientAsync(Patient patients)
        {

            try
            {
                await _db.SaveData("sp_InsertPatient", new { patients});
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeletePatientAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_DeletePatient", new { PatientID = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            string query = "sp_GetPatientDetails";
            return await _db.GetData<Patient, dynamic>(query, new { });
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            IEnumerable<Patient> result = await _db.GetData<Patient, dynamic>("sp_GetPatientDetails", new { PatientID = id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<PatientsDisplayViewModel>> GetPatientInfo()
        {
            string query = "sp_PatientsDisplayViewModel";
            return await _db.GetData<PatientsDisplayViewModel, dynamic>(query, new { });
        }

        public async Task<bool> UpdatePatientAsync(Patient patient)
        {
            try
            {

                await _db.SaveData("sp_UpdatePatient", patient);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
