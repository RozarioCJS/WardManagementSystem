using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class PatientVitalsViewModel
    {
        public string VitalName { get; set; }
        public string PatientVitalsValue { get; set; }
        public DateTime Date {  get; set; }
        public string Time {  get; set; }
    }
}
