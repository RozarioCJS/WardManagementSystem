using WardManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;

namespace WardManagementSystem.Data.Repository
{
    public interface IWardConsumableRepository
    {
        Task<IEnumerable<Ward>> GetAllAsync();
        Task<IEnumerable<WardConsumableStockViewModel>> GetByIdAsync(int id);

    }
}
