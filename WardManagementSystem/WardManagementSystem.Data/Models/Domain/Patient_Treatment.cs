using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Patient_Treatment
    {
        [Key]
        public int PatientTreatmentID { get; set; }
        public int TreatmentID { get; set; }
        public int VisitID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string SurgaryRoom { get; set; }
    }
}
