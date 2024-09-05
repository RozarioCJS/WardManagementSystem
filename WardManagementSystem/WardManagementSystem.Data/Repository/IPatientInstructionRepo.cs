using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;

namespace WardManagementSystem.Data.Repository
{
    public interface IPatientInstructionRepo
    {
        Task<bool> AddAsync(Patient_Instruction instruction);
        Task<bool> UpdateAsync(Patient_Instruction instruction);
        Task<bool> DeleteAsync(int id);
        Task<Patient_Instruction> GetByIdAsync(int id);
        Task<IEnumerable<Patient_Instruction>> GetAllAsync();
    }
}
