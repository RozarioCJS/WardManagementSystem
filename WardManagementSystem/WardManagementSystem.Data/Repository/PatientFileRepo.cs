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
    public class PatientFileRepo : IPatientFileRepo
    {
        private readonly ISqlDataAccess _db;
        public PatientFileRepo(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<PatientFileViewModel>> DisplayAllPatientFileAsync(int PatientID)
        {
            var query = "sp_DisplayPatientFile";
            return await _db.GetData<PatientFileViewModel, dynamic>(query, new { PatientID = PatientID });
        }

        public async Task<IEnumerable<PatientChronicConditionViewModel>> DisplayAllChronicConditionAsync(int PatientID)
        {
            var query = "sp_DisplayPatientChronicCondition";
            return await _db.GetData<PatientChronicConditionViewModel, dynamic>(query, new { PatientID = PatientID });
        }

        public async Task<IEnumerable<PatientAllergyViewModel>> DisplayAllPatientAllergyAsync(int PatientID)
        {
            var query = "sp_DisplayPatientAllergy";
            return await _db.GetData<PatientAllergyViewModel, dynamic>(query, new { PatientID = PatientID });
        }

        public async Task<IEnumerable<PatientMedicationViewModel>> DisplayAllPatientMedicationAsync(int PatientID)
        {
            var query = "sp_DisplayPatientMedication";
            return await _db.GetData<PatientMedicationViewModel, dynamic>(query, new { PatientID = PatientID });
        }

        public async Task<IEnumerable<PatientTreatmentViewModel>> DisplayAllPatientTreatmentAsync(int PatientID)
        {
            var query = "sp_DisplayPatientTreatment";
            return await _db.GetData<PatientTreatmentViewModel, dynamic>(query, new { PatientID = PatientID });
        }

        public async Task<IEnumerable<PatientVitalsViewModel>> DisplayAllPatientVitalsAsync(int PatientID)
        {
            var query = "sp_DisplayPatientVitals";
            return await _db.GetData<PatientVitalsViewModel, dynamic>(query, new { PatientID = PatientID });
        }

        public async Task<IEnumerable<PatientComboViewModel>> GetPatientFullNameAsync()
        {
            var query = "sp_PatientComboBox";
            return await _db.GetData<PatientComboViewModel, dynamic>(query, new { });
        }
    }
}
