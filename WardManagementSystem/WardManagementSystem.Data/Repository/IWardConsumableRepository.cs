using WardManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;

namespace WardManagementSystem.Data.Repository
{
    public interface IWardConsumableRepository
    {
        Task<IEnumerable<Ward>> GetAllAsync();
        Task<IEnumerable<Consumable>> GetAllConsumablesAsync();
        Task<IEnumerable<WardConsumableStockViewModel>> GetByIdAsync(int id);
        Task<bool> UpdateStockAsync(int WardID, int ConsumableID, int Quantity);
        Task<int> AddPurchaseOrderAsync(int SupplierID, int ConsumableManagerID, int WardID);
        Task<bool> AddPurchaseOrderDetailAsync(int PurchaseOrderID, int ConsumableID, int Quantity);
        Task<bool> PurchaseUpdatetWardConsumableStock(int WardID, int ConsumableID, int Quantity);
        Task<IEnumerable<LatestPurchaseOrder>> GetLatestPurchaseOrderAsync();
    }
}
