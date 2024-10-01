using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P paramters, string connectionId = "connectionString");
        Task SaveData<P>(string spName, P paramters, string connectionId = "connectionString");
    }
}
