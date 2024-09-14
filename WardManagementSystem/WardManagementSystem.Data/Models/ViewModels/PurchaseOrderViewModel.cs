using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class PurchaseOrderViewModel
    {
        [Key]
        public int PurchaseOrderID { get; set; }

        [Required]
        public int SupplierID { get; set; }
        public string? SupplierName { get; set; }

        [Required]
        public int ConsumableMangerID { get; set; }
        public string? ConsumableManagerName { get; set; }

        public List<PurchaseOrderDetailViewModel> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetailViewModel>();
    }
}
