﻿using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models.Domain; // Ensure the right namespace is used
using WardManagementSystem.Data.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public class AdmissionRepository : IAdmissionRepository // Remove inner class if present
    {
        private readonly ISqlDataAccess _db;

        public AdmissionRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAdmissionAsync(Admission admission) 
        {
            try
            {
                await _db.SaveData("sp_InsertAdmission", new { admission });
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        public async Task<bool> DeleteAdmissionAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_DeleteAdmission", new { AdmissionID = id });
                return true;
            }
            catch (Exception ex)
            {
                return false; // Consider logging the exception
            }
        }

        public async Task<IEnumerable<Admission>> GetAllAdmissionAsync()
        {
            string query = "sp_GetAllAdmissions";
            return await _db.GetData<Admission, dynamic>(query, new { });
        }

        public async Task<AdmissionsViewModel> GetAdmissionByIdAsync(int id)
        {
            IEnumerable<AdmissionsViewModel> result = await _db.GetData<AdmissionsViewModel, dynamic>("sp_GetAdmission", new { AdmissionID = id });
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateAdmissionAsync(AdmissionsViewModel admission) // Ensure to use Domain Admission
        {
            try
            {
                await _db.SaveData("sp_UpdatePatient", admission);
                return true;
            }
            catch (Exception ex)
            {
                return false; // Consider logging the exception
            }
        }
    }
}
