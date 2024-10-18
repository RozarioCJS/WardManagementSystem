using WardManagementSystem.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Repository
{
    public interface IPatientMovementRepository
    {  
            Task<bool> AddMovementAsync(Movement movement);
            Task<IEnumerable<Movement>> GetMovementsByPatientIdAsync(int patientId);
            Task<bool> UpdateMovementAsync(Movement movement);      
    }
}
