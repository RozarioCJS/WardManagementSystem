using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using System.Data;
using Dapper;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace WardManagementSystem.Data.Repository
{
    public class WardConsumableRepository : IWardConsumableRepository
    {
        private readonly ISqlDataAccess _db;
        public WardConsumableRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Ward>> GetAllAsync()
        {
            return await _db.GetData<Ward, dynamic>("spGetWards", new { });
        }
        public async Task<IEnumerable<WardConsumableStockViewModel>> GetByIdAsync(int Id)
        {
            return await _db.GetData<WardConsumableStockViewModel, dynamic>("spGetWardConsumables", new { Id = Id });
        }
        public async Task<bool> UpdateStockAsync(int WardID, int ConsumableID, int Quantity)
        {
            try
            {
                await _db.SaveData("sp_UpdateWardConsumableStock", new { WardID, ConsumableID, Quantity });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //The mess below handles the purchase related things
        public async Task<int> AddPurchaseOrderAsync(int SupplierID, int ConsumableManagerID, int WardID)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SupplierID", SupplierID);
            parameters.Add("@ConsumableManagerID", ConsumableManagerID);
            parameters.Add("@WardID", WardID);
            parameters.Add("@PurchaseOrderID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _db.SaveData("sp_AddPurchaseOrder", parameters );

            return parameters.Get<int>("@PurchaseOrderID");
        }
        
        public async Task<bool> AddPurchaseOrderDetailAsync(int PurchaseOrderID, int ConsumableID, int Quantity)
        {
            try
            {
                await _db.SaveData("sp_AddPurchaseOrderDetail", new { PurchaseOrderID, ConsumableID, Quantity });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> PurchaseUpdatetWardConsumableStock(int WardID, int ConsumableID, int Quantity)
        {
            try
            {
                await _db.SaveData("sp_PurchaseUpdateWardConsumableStock", new { WardID, ConsumableID, Quantity });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
