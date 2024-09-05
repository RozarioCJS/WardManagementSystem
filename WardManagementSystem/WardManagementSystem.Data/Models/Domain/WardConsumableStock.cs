using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.Domain
{
    public class WardConsumableStock
    {
        [Key]
        public int WardConsumableStockID { get; set; }
        public int WardID { get; set; }
        public Ward Ward { get; set; }
        public int ConsumableID { get; set; }
        public Consumable Consumable { get; set; }
        public int Quantity { get; set; }
    }
}
