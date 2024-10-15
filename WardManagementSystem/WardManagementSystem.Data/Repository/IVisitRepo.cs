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
        Task<bool> AddAsync(Visit visit, int DoctorID);
        Task<bool> UpdateAsync(Visit visit);
        Task<bool> DeleteAsync(int id);
        Task<Visit> GetByIdAsync(int id);
        Task<IEnumerable<VisitNoteViewModel>> GetAllAsync(int PatientFileID, int DoctorID);
        Task<IEnumerable<DoctorFullNameViewModel>> GetDoctorFullNameAsync();        //used to fill drop down list with doctor name
        Task<IEnumerable<PatientFileFullNameViewModel>> GetPatientFileFullNameAsync();
    }
}
