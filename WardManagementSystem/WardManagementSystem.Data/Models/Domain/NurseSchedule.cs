using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class NurseSchedule
    {
        
            public int Id { get; set; }
            public int NurseId { get; set; }
            public int Date {  get; set; }
            public DateTime ShiftStart { get; set; }
            public DateTime ShiftEnd { get; set; }
            public string ShiftType { get; set; } // E.g., Day, Night, etc.
        
    }
}
