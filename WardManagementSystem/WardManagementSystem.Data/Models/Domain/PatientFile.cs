using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class PatientFile
    {
        [Key]
        public int PatientFileID { get; set; }
        public int PatientID { get; set; } //TODO: nav prop
        public string ArrivalDate { get; set; }
        public int BedID { get; set; } // TODO: nav prop
        public string Status { get; set; }
    }
}
