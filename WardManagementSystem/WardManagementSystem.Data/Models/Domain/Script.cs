using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Script
    {
        [Key]
        public int ScriptID { get; set; }
        public int DoctorID { get; set; }
        public int PatientFileID { get; set; }
        public int MedicationID { get; set; }
        public int? PrescriptionManagerID { get; set; }
        public DateTime? Date {  get; set; }     
        public char? Status { get; set; }
        public string Dosage { get; set; }
    }
}
