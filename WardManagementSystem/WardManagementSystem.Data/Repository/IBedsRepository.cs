using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public interface IBedsRepository
    {
        Task<IEnumerable<Beds>> GetAllBedsAsync();
        Task<Beds> GetBedsByIdAsync(int id);
        Task<bool> AddBedsAsync(Beds bed);
        Task<bool> UpdateBedsAsync(Beds bed);
        Task<bool> DeleteBedsAsync(int id);
        //Task<bool> AddBedsAsync(BedsRepository bed);
    }
}
