﻿using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using System.Data;

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
    }
}
