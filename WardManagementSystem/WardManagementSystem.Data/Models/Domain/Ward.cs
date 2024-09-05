using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class Ward
    {
        [Key]
        public int WardID { get; set; }
        public string WardName { get; set; }
        public int WardNumber { get; set; }
    }
}
