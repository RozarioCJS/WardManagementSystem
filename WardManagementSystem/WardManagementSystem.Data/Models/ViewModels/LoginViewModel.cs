using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string LastName { get; set; }
        public int? DoctorID { get; set; } // Changed to nullable
        public int? ConsumableManagerID { get; set; } // Changed to nullable
        public int? PrescriptionManagerID { get; set; } // Changed to nullable
        public int? AdminID { get; set; } // Added for Admin
        public int? WardAdminID { get; set; } // Added for Ward Admin
        public int? SisterID { get; set; } // Added for Sister Nurse
        public int? NurseID { get; set; } // Added for Nurse
    }

}


