using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models
{
    public class ScriptStatusCountViewModel
    {
        public int NewCount { get; set; }
        public int ProcessedCount { get; set; }
        public int ReceivedCount { get; set; }
    }
}
