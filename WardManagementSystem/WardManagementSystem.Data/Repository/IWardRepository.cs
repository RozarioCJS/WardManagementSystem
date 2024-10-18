using WardManagementSystem.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public interface IWardRepository
    {
        Task<IEnumerable<Ward>> GetAllWardAsync();
        Task<Ward> GetWardByIdAsync(int id);
        Task<bool> AddWardAsync(Ward ward);
        Task<bool> UpdateWardAsync(Ward ward);
        Task<bool> DeleteWardAsync(int id);
        
    }
}
