using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;

namespace WardManagementSystem.Data.Repository
{
    public interface IScriptRepo
    {
        Task<bool> AddAsync(Script script);
        Task<bool> UpdateAsync(Script script);
        Task<bool> DeleteAsync(int id);
        Task<Script> GetByIdAsync(int id);
        Task<IEnumerable<Script>> GetAllAsync();
    }
}
