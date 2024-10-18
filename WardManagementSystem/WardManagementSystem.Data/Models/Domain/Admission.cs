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
        public string FirstName { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string AdmissionReason { get; set; }
        public string WardName { get; set; }
        public string DoctorName { get; set; }
        public string AdmissionStatus { get; set; }
        // public int WardID { get; set; }
    }
}
