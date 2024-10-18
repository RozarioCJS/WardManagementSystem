using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class PatientsDisplayViewModel
    {
        
        public int PatientID { get; set; }
        public string PatientFullName { get; set; }
        public string AllergyName { get; set;}
        public string Gender { get; set;}   
        public int ContactNumber { get; set;}
        public string Email { get; set;}
        public string Address1 { get; set;}
        public string Address2 { get; set;} 
    }
}
