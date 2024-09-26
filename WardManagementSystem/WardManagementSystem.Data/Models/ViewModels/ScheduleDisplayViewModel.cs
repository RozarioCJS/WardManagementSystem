using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class ScheduleDisplayViewModel
    {
        public int ScheduleID { get; set; }
        public int PatientID { get; set; }
        public string PatientFullName { get; set; }
        public DateTime Date {  get; set; }
        public string Time {  get; set; }
    }
}
