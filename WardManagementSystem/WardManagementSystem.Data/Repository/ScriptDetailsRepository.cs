using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;

namespace WardManagementSystem.Data.Repository
{
    public class ScriptDetailsRepo : IScriptDetailsRepo
    {
        private readonly ISqlDataAccess _db;
        public ScriptDetailsRepo(ISqlDataAccess db)
        {
            _db = db;
        }
        public async Task<bool> UpdateAsync(Script script)
        {
            try
            {
                var parameters = new
                {
                    Id = script.ScriptID,
                };
                await _db.SaveData("UpdateStatus", parameters);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Update failed for ScriptDetailID: " + script.ScriptID + " Error: " + ex.Message);
                return false;
            }
        }
        public async Task<ScriptDetailsViewModel> GetByIdAsync(int id)
        {
            IEnumerable<ScriptDetailsViewModel> result = await _db.GetData<ScriptDetailsViewModel, dynamic>("DisplayNewScriptDetail", new { ID = id });
            return result.FirstOrDefault();
        }
        public async Task<IEnumerable<ScriptListViewModel>> GetAllAsync(char status)
        {
            return await _db.GetData<ScriptListViewModel, dynamic>("ListAllNewScripts", new { Status = status });
        }
    }
}
