using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.DataAccess;

namespace WardManagementSystem.Data.Repository
{
    public class PatientInstructionRepo : IPatientInstructionRepo
    {
        private readonly ISqlDataAccess _db;
        public PatientInstructionRepo(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Patient_Instruction instruction)
        {
            try
            {
                await _db.SaveData("sp_CreatePatientInstruction", new { instruction.PatientFileID, instruction.DoctorID, instruction.Instruction });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Patient_Instruction>> GetAllAsync()
        {
            string query = "sp_ViewPatientInstructions";
            return await _db.GetData<Patient_Instruction, dynamic>(query, new { });
        }

        public async Task<Patient_Instruction> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Patient_Instruction instruction)
        {
            throw new NotImplementedException();
        }
    }
}
