using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Script_Detail
    {
        [Key]
        public int ScriptDetailID { get; set; }
        public int ScriptID { get; set; }
        public int MedicationID { get; set; }
        public string Date { get; set; }            //remember why string is used instead of DateTime (Fix in SQL Server as well)
        public char Status { get; set; }
        public int Dosage { get; set; }
    }
}
