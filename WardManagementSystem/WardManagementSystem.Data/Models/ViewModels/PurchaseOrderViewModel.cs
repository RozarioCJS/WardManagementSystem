using Microsoft.Identity.Client;
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
        public int SupplierID { get; set; }
        public int ConsumableManagerID { get; set; }
        public int WardID { get; set; }
        public List<ConsumableOrder> ConsumableOrders { get; set; } = new List<ConsumableOrder>();
    }
}
