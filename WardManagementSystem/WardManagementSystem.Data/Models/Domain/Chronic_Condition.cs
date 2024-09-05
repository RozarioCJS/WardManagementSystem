using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Chronic_Condition
    {
        [Key]
        public int ConditionID { get; set; }
        public string ConditionName { get; set; }
    }
}
