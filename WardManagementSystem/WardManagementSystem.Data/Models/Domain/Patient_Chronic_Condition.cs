using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Patient_Chronic_Condition
    {
        [Key]
        public int PatientChronicConditionID {  get; set; }
        public int PatientID { get; set; }
        public int ConditionID { get; set; }
    }
}
