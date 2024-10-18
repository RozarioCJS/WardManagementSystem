using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class PatientFolder
    {
        [Key]
        public int PatientFileID { get; set; }
        [Required]
        public int PatientID { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int BedID { get; set; }

        public string AdmissionStatus { get; set; }

        public string DoctorName { get; set; }
        public int WardID { get; set; }
    }
}
