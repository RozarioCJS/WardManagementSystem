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
        Task<IEnumerable<Admission>> GetAllAdmissionAsync();
        Task<AdmissionsViewModel> GetAdmissionByIdAsync(int id);
        Task<bool> AddAdmissionAsync(Admission admission);
        Task<bool> UpdateAdmissionAsync(AdmissionsViewModel admission);
        Task<bool> DeleteAdmissionAsync(int id);
        //Task<bool> UpdateAdmissionAsync(Models.Domain.Admission admission);
    }
}
