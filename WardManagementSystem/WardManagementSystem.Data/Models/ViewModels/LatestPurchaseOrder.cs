using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class LatestPurchaseOrder
    {
        public string SupplierName { get; set; }
        public string LastName { get; set; }
        public string ConsumableName { get; set; }
        public int Quantity { get; set; }
    }
}
