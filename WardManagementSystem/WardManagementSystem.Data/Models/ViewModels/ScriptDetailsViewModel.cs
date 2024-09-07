using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models
{
    public class ScriptDetailsViewModel
    {
        public int ScriptID { get; set; }
        public string FirstName { get; set; }
        public DateTime Date { get; set; }
        public string PatientName { get; set; }
        public char Status { get; set; }
        public string medicationName { get; set; }
        public int Dosage { get; set; }
    }
}
