using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public interface IScriptDetailsRepo
    {
        Task<bool> UpdateAsync(Script Script);
        Task<bool> ReceivedScriptsAsync(Script Script);
        Task<ScriptDetailsViewModel> GetByIdAsync(int id);
        Task<IEnumerable<ScriptListViewModel>> GetAllAsync(char status);
        Task<IEnumerable<ScriptListViewModel>> GetByDateAsync(DateTime SearchDate);
    }
}
