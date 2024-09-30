using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class PatientScriptViewModel
    {
        public int ScriptID { get; set; }
        public int DoctorID { get; set; }
        public int PatientFileID { get; set; }
        public string PatientName { get; set; }
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public DateTime Date {  get; set; }
        public string Dosage { get; set; }
    }
}
