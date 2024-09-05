using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Medication
    {
        [Key]
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public string MedicationType { get; set; }
    }
}
