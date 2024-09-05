using WardManagementSystem.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();  
        Task<Patient> GetPatientByIdAsync(int id);  
        Task<int> AddPatientAsync(Patient patient);  
        Task<int> UpdatePatientAsync(Patient patient);  
        Task<int> DeletePatientAsync(int id); 
    }
}
