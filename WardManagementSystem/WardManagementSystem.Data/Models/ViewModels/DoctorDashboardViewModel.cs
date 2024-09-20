using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models
{
    public class DoctorDashboardViewModel
    {
        //public int PatientID { get; set; }
        //public int DoctorID { get; set; }
        //public DateTime Date { get; set; }
        /*public DateTime Date { get; set; } */       //  GET THE CORRECT DATA TYPE!!!!!!

        public int DoctorID { get; set; }
        public string PatientName { get; set; }
        public DateTime Date { get; set; }        //  GET THE CORRECT DATA TYPE!!!!!! 
        public string Time { get; set; }
    }
}
