using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class AdmissionsViewModel
    {
        public int AdmissionID { get; set; }
        public string PatientFullName { get; set; }
        public string DoctorFullName { get; set; }
        public string AdmissionReason { get; set; }
        public string WardName { get; set; }
        public string AdmissionDate { get; set; }
        public string AdmissionStatus { get; set; }
        public int BedID{ get; set; }
    }
}
