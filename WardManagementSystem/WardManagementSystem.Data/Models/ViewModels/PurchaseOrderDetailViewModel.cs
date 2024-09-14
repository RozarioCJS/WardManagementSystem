using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class PurchaseOrderDetailViewModel
    {
        [Key]
        public int PurchaseOrderDetailID { get; set; }

        [Required]
        public int ConsumableID { get; set; }
        public string? ConsumableName { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
