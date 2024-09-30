using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;

namespace WardManagementSystem.Data.Repository
{
    public interface IVisitRepo
    {
        Task<bool> AddAsync(Visit visit);
        Task<bool> UpdateAsync(Visit visit);
        Task<bool> DeleteAsync(int id);
        Task<Visit> GetByIdAsync(int id);
        Task<IEnumerable<VisitNoteViewModel>> GetAllAsync(int PatientFileID);
        Task<IEnumerable<PatientFileFullNameViewModel>> GetPatientFileFullNameAsync();
    }
}
