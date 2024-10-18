using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public class BedsRepository : IBedsRepository
    {
        private readonly ISqlDataAccess _db;

        public BedsRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddBedsAsync(Beds bed)
        {
            try
            {
                await _db.SaveData("sp_InsertBed", new { bed }); // Changed stored procedure name
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBedsAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_DeleteBeds", new { BedID = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Beds>> GetAllBedsAsync()
        {
            string query = "sp_GetBeds";
            return await _db.GetData<Beds, dynamic>(query, new { });
        }

        public async Task<Beds> GetBedsByIdAsync(int id)
        {
            IEnumerable<Beds> result = await _db.GetData<Beds, dynamic>("sp_GetBeds", new { BedID = id });
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateBedsAsync(Beds bed)
        {
            try
            {
                await _db.SaveData("sp_UpdateBed", bed); // Ensure stored procedure name matches your DB
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
