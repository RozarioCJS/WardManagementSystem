using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models
{
    public class ScriptListViewModel
    {
        public int ScriptID { get; set; }
        public string FirstName { get; set; }
        public DateTime Date { get; set; }
        public char Status { get; set; }
    }
}
