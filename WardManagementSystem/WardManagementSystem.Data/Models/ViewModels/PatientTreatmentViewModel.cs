using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class PatientTreatmentViewModel
    {
        public int PatientID { get; set; }
        public string TreatmentName { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string SurgaryRoom { get; set; }
    }
}
