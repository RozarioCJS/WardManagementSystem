using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;

namespace WardManagementSystem.Data.Repository
{
    public interface IPatientFileRepo
    {
        Task<IEnumerable<PatientFileViewModel>> DisplayAllPatientFileAsync(int PatientID);
        Task<IEnumerable<PatientChronicConditionViewModel>> DisplayAllChronicConditionAsync(int PatientID);
        Task<IEnumerable<PatientAllergyViewModel>> DisplayAllPatientAllergyAsync(int PatientID);
        Task<IEnumerable<PatientMedicationViewModel>> DisplayAllPatientMedicationAsync(int PatientID);
        Task<IEnumerable<PatientTreatmentViewModel>> DisplayAllPatientTreatmentAsync(int PatientID);
        Task<IEnumerable<PatientVitalsViewModel>> DisplayAllPatientVitalsAsync(int PatientID);

        Task<IEnumerable<PatientFullNameViewModel>> GetPatientFullNameAsync();
    }
}
