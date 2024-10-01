using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;

namespace WardManagementSystem.Data.Repository
{
    public interface IScriptRepo
    {
        Task<bool> AddAsync(Script script);
        Task<bool> UpdateAsync(Script script);
        Task<bool> DeleteAsync(int id);
        Task<Script> GetByIdAsync(int id);
        Task<IEnumerable<Script>> GetAllAsync();
        Task<IEnumerable<DoctorFullNameViewModel>> GetDoctorFullNameAsync();        //used to fill drop down list with doctor name
        Task<IEnumerable<PatientFileFullNameViewModel>> GetPatientFullNameAsync();  //for loading the patient name drop down list
        Task<IEnumerable<MedicationNameViewModel>> GetMedicationNameAsync();    //for loading the medication drop down list
        Task<IEnumerable<PatientScriptViewModel>> GetAllPatientAsync(int PatientFileID);
    }
}
