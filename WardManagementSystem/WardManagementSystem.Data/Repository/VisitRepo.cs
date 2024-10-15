using iText.StyledXmlParser.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace WardManagementSystem.Data.Repository
{
    public class VisitRepo : IVisitRepo
    {
        private readonly ISqlDataAccess _db;
        public VisitRepo(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Visit visit, int DoctorID)
        {
            try
            {
                await _db.SaveData("sp_CreateVisitNote", new { DoctorID, visit.PatientFileID, visit.VisitNote, visit.DischargePatient });
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
                await _db.SaveData("sp_DeleteVisitNote", new { VisitID = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Visit> GetByIdAsync(int id)
        {
            IEnumerable<Visit> result = await _db.GetData<Visit, dynamic>("sp_FindVisit", new { VisitID = id });
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(Visit visit)
        {
            try
            {
                await _db.SaveData("sp_UpdateVisitNote", new { visit.VisitID, visit.VisitNote, visit.DischargePatient});
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


        public async Task<IEnumerable<PatientFileFullNameViewModel>> GetPatientFileFullNameAsync()
        {
            var query = "sp_PatientFullName_PatientFile";
            return await _db.GetData<PatientFileFullNameViewModel, dynamic>(query, new { });
        }

        public async Task<IEnumerable<VisitNoteViewModel>> GetAllAsync(int PatientFileID, int DoctorID)
        {
            string query = "sp_DisplayVisitVM";
            return await _db.GetData<VisitNoteViewModel, dynamic>(query, new { PatientFileID = PatientFileID, DoctorID = DoctorID});
        }
    }
}
