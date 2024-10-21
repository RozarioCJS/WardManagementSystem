using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class SisterNurseTask
    {
        public int Id { get; set; } // Unique identifier for the task
        public string Description { get; set; } // Description of the task
        public DateTime DueDate { get; set; } // Due date for the task
        public bool IsCompleted { get; set; } // Status of the task
        public int SisterNurseId { get; set; } // Reference to the Sister Nurse
    }
}
