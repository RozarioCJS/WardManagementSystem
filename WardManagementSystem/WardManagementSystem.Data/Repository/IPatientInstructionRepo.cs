using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;

namespace WardManagementSystem.Data.Repository
{
    public interface IPatientInstructionRepo
    {
        Task<bool> AddAsync(Patient_Instruction patient_instruction);
        Task<bool> UpdateAsync(Patient_Instruction patient_instruction);
        Task<bool> DeleteAsync(int id);
        Task<Patient_Instruction> GetByIdAsync(int id);
        Task<IEnumerable<Patient_Instruction>> GetAllAsync();
        Task<IEnumerable<PatientFileFullNameViewModel>> GetPatientFullNameAsync();      //used to fill drop down list with patient name
        Task<IEnumerable<DoctorFullNameViewModel>> GetDoctorFullNameAsync();        //used to fill drop down list with doctor name
        Task<IEnumerable<PatientInstructionViewModel>> GetAllPatientNameAsync(int PatientFileID);
    }
}
