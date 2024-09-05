using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Patient_Allergy
    {
        public int PatientAllergyID { get; set; }
        public int PatientID { get; set; }
        public int AllergyID { get; set; }
    }
}
