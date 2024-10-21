using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class SisterNurseTasks
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
