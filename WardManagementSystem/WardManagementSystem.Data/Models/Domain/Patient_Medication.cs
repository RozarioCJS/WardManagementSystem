using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Patient_Medication
    {
        [Key]
        public int PatientMedicationID { get; set; }
        public int PatientID { get; set; }
        public int MedicationID { get; set; }
    }
}
