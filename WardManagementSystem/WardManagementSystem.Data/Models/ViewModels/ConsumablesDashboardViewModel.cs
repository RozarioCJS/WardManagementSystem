using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;

namespace WardManagementSystem.Data.Models.ViewModels
{
    public class ConsumablesDashboardViewModel
    {
        public IEnumerable<Ward> ConWards { get; set; }
        public IEnumerable<LatestPurchaseOrder> LateOrder { get; set; }
    }
}
