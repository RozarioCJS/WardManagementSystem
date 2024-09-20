using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class PatientTreatmentViewModel
    {
        public string TreatmentName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string SurgaryRoom { get; set; }
    }
}
