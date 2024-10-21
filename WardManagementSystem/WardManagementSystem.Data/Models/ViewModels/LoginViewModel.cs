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
        public string Role {  get; set; }
        public string LastName { get; set; }
        public int DoctorID { get; set; }
        public int ConsumableManagerID { get; set; }
        public int PrescriptionManagerID { get; set; }
        public int SisterID { get; set; }
        public int NurseID { get; set; }

    }
}
