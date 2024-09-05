using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Patient_File
    {
        [Key]
        public int PatientFileID { get; set; }
        public int PatientID { get; set; }
        public string ArrivalDate { get; set; }
        public int BedID { get; set; }
        public string Status { get; set; }
    }
}
