using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class PatientInstructionViewModel
    {
        public int PatientInstructionID { get; set; }
        public int PatientFileID { get; set; }
        public int DoctorId { get; set; }
        public string PatientName  { get; set; }
        public string Instruction {  get; set; }
        public DateTime Date { get; set; }

    }
}
