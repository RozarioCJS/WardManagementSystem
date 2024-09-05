using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Patient_Vitals
    {
        [Key]
        public int PatientVitalsID { get; set; }
        public int PatientFileID { get; set; }
        public int VitalsID { get; set; }
        public int PatientVitalsValue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
