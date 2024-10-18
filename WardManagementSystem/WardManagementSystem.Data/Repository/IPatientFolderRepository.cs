using WardManagementSystem.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public interface IPatientFolderRepository
    {
        Task<IEnumerable<PatientFolder>> GetAllPatientFolderAsync();
        Task<PatientFolder> GetPatientFolderByIdAsync(int id);
        Task<bool> AddPatientFolderAsync(PatientFolder patientfolder);
        Task<bool> UpdatePatientFolderAsync(PatientFolder patientfolder);
        Task<bool> DeletePatientFolderAsync(int id);
        Task GetPatientFolderByIdAsync(string firstName);
    }
}
