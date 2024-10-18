using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class PatientFileViewModel
    {
        public int PatientID { get; set; }
        public string PatientFullName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int BedID { get; set; }
        public string WardName { get; set; }
    }
}
