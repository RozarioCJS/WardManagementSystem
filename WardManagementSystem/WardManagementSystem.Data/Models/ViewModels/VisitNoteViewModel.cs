using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class VisitNoteViewModel
    {
        public int VisitID { get; set; }
        public int DoctorID { get; set; }
        public int PatientFileID { get; set; }
        public string PatientName { get; set; }
        public string VisitNote {  get; set; }
        public DateTime Date { get; set; }
        public string DischargePatient {  get; set; }
    }
}
