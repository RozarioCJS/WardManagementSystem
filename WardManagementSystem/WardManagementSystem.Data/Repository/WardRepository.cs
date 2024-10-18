using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{

        public class WardRepository : IWardRepository
        {
            private readonly ISqlDataAccess _db;

            public WardRepository(ISqlDataAccess db)
            {
                _db = db;
            }
            public async Task<bool> AddWardAsync(Ward ward)
            {

                try
                {
                    await _db.SaveData("sp_InsertWard", new { ward });
                    return true;
                }

                catch (Exception ex)
                {
                    return false;
                }
            }
            public async Task<bool> DeleteWardAsync(int id)
            {
                try
                {
                    await _db.SaveData("sp_DeleteWards", new { WardID = id });
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            public async Task<IEnumerable<Ward>> GetAllWardAsync()
            {
                string query = "sp_GetWards";
                return await _db.GetData<Ward, dynamic>(query, new { });
            }

            public async Task<Ward> GetWardByIdAsync(int id)
            {
                IEnumerable<Ward> result = await _db.GetData<Ward, dynamic>("sp_GetWards", new { WardID = id });
            return result.FirstOrDefault();
            }

            public async Task<bool> UpdateWardAsync(Ward ward)
            {
                try
                {

                    await _db.SaveData("sp_UpdateWards", ward);
                    return true;
                }
                catch (Exception)
            {
                    return false;
                }
            }
        }
    }



