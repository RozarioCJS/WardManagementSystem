using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Admission
    {
        [Key]
        public int AdmissionID { get; set; }
        public int PatientID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string AdmissionReason { get; set; }
        public int WardID { get; set; }
        public int DoctorID { get; set; }
        public string AdmissionStatus { get; set; }
        // public int WardID { get; set; }
    }
}
