using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime Date {  get; set; }
        public string Time {  get; set; }   //Time will be static (hard-coded) in 30 minute increments. May change down the line.
    }
}
