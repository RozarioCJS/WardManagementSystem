using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain; // Ensure this is included


namespace WardManagementSystem.Data.Models.ViewModels
{
    public class SisterNurseDashboardViewModel
    {
        public List<SisterNurseTask> Tasks { get; set; }
        public string LastName { get; set; } // Example of additional data
    }
}
