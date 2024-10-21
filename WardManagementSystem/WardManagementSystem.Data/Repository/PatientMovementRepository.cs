using WardManagementSystem.Data.DataAccess;
using WardManagementSystem.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public class PatientMovementRepository : IPatientMovementRepository
    {
        private readonly ISqlDataAccess _db;

        public PatientMovementRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddMovementAsync(Movement movement)
        {
            try
            {
                await _db.SaveData("sp_TrackPatientMovement", movement);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Movement>> GetMovementsByPatientIdAsync(int patientId)
        {
            return await _db.GetData<Movement, dynamic>("sp_GetMovementsByPatientId", new { PatientId = patientId });
        }

        public async Task<bool> UpdateMovementAsync(Movement movement)
        {
            try
            {
                await _db.SaveData("sp_UpdateMovement", movement);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
