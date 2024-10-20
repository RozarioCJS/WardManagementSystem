﻿using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.DataAccess;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using WardManagementSystem.Data.Models.ViewModels;

namespace WardManagementSystem.Data.Repository
{
    public class PatientInstructionRepo : IPatientInstructionRepo
    {
        private readonly ISqlDataAccess _db;
        public PatientInstructionRepo(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Patient_Instruction patient_instruction, int DoctorID)
        {
            try
            {
                await _db.SaveData("sp_CreatePatientInstruction", new { patient_instruction.PatientFileID, DoctorID, patient_instruction.Instruction });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_DeletePatientInstruction", new { PatientInstructionID = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Patient_Instruction>> GetAllAsync()
        {
            string query = "sp_ViewPatientInstructions";
            return await _db.GetData<Patient_Instruction, dynamic>(query, new { });
        }

        public async Task<Patient_Instruction> GetByIdAsync(int id)
        {
            IEnumerable<Patient_Instruction> result = await _db.GetData<Patient_Instruction, dynamic>("sp_FindPatientInstruction", new { PatientInstructionID = id });
            return result.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(Patient_Instruction patient_instruction)
        {
            try
            {
                await _db.SaveData("sp_UpdatePatientInstruction", new { patient_instruction.PatientInstructionID, patient_instruction.Instruction });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<PatientFileFullNameViewModel>> GetPatientFullNameAsync()
        {
            var query = "sp_PatientFullName_PatientFile";
            return await _db.GetData<PatientFileFullNameViewModel, dynamic>(query, new { });
        }

        public async Task<IEnumerable<DoctorFullNameViewModel>> GetDoctorFullNameAsync()
        {
            var query = "sp_DoctorFullName";
            return await _db.GetData<DoctorFullNameViewModel, dynamic>(query, new { });
        }


        public async Task<IEnumerable<PatientInstructionViewModel>> GetAllPatientNameAsync(int PatientFileID, int DoctorID)
        {
            var query = "sp_PatientInstructionVM";
            return await _db.GetData<PatientInstructionViewModel, dynamic>(query, new { PatientFileID = PatientFileID, DoctorID = DoctorID});
        }
    }
}
