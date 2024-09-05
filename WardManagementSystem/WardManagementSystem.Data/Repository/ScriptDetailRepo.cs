using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Data.Repository
{
    public class ScriptDetailRepo : IScriptDetailRepo
    {
        private readonly ISqlDataAccess _db;
        public ScriptDetailRepo(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Script_Detail scriptDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Script_Detail scriptDetail)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Script_Detail>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Script_Detail scriptDetail)
        {
            throw new NotImplementedException();
        }
    }
}
