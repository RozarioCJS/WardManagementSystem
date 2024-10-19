using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public interface IAdmissionRepository
    {
        Task<IEnumerable<AdmissionsViewModel>> GetAllAdmissionAsync();
        Task<AdmissionsViewModel> GetAdmissionByIdAsync(int id);
        Task<bool> AddAdmissionAsync(Admission admission);
        Task<bool> UpdateAdmissionAsync(AdmissionsViewModel admission);
        Task<bool> DeleteAdmissionAsync(int id);
        Task<IEnumerable<PatientFullNameViewModel>> GetPatientFullNameAsync();      //used to fill drop down list with patient name
        Task<IEnumerable<DoctorFullNameViewModel>> GetDoctorFullNameAsync();        //used to fill drop down list with doctor name
        Task<IEnumerable<WardFullNameViewModel>> GetWardFullNameAsync();        //used to fill drop down list with ward name
        //Task<bool> UpdateAdmissionAsync(Models.Domain.Admission admission);
    }
}
