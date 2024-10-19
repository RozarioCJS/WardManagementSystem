using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Visit
    {
        [Key]
        public int VisitID { get; set; }
        public int DoctorID { get; set; }
        public int PatientFileID { get; set; }
        [StringLength(250)]
        public string VisitNote { get; set; }
        public DateTime Date { get; set; }
        public bool DischargePatient { get; set; }
    }
}
