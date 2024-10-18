using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class UpdatePatientFolderViewModel
    {
        public int PatientFileID { get; set; }
        public int PatientID { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int BedID { get; set; }
        public int WardID { get; set; }
        public string AdmissionStatus { get; set; }
        public string DoctorName { get; set; }

    }
}
