using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Patient_Instruction
    {
        [Key]
        public int PatientInstructionID { get; set; }
        public int PatientFileID { get; set; }
        public int DoctorID { get; set; }
        public string Instruction { get; set; }
    }
}
