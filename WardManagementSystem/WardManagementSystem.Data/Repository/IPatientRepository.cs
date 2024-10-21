using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public interface IPatientRepository
    {
        //Task<IEnumerable<Patient>> GetAllPatientsAsync();  
        Task<PatientsDisplayViewModel> GetPatientByIdAsync(int id);  
        Task<bool> AddPatientAsync(Patient patient);  
        Task<bool> UpdatePatientAsync(Patient patient);  
        Task<bool> DeletePatientAsync(int id);
        Task<IEnumerable<PatientsDisplayViewModel>> GetPatientInfo();
        Task<IEnumerable<AllergyNameViewModel>> GetAllergyName();
        Task<IEnumerable<PatientListViewModel>> GetPatientListAsync();
    }
}
