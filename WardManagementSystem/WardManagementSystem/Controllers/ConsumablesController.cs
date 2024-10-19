using Microsoft.AspNetCore.Mvc;
using System;
using WardManagementSystem.Data.Models;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class ConsumablesController : Controller
    {
        private readonly IWardConsumableRepository _WCRepo;
        public ConsumablesController(IWardConsumableRepository WCRepo)
        {
            _WCRepo = WCRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var temp = HttpContext.Session.GetInt32("ConsumableManagerID");
            int CMID = (int)temp;

            var conWards = await _WCRepo.GetAllAsync();
            var Lateorder = await _WCRepo.GetLatestPurchaseOrderAsync();
            var viewModel = new ConsumablesDashboardViewModel
            {
                ConWards = conWards,
                LateOrder = Lateorder
            };
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var wardConsumables = await _WCRepo.GetByIdAsync(Id);
            return View("Details", wardConsumables);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder()
        {
            return RedirectToAction("Details");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStock(int WardID, int ConsumableID, int Quantity, string ConsumableName)
        {
            try
            {
                bool updateConsuambles = await _WCRepo.UpdateStockAsync(WardID, ConsumableID, Quantity);

                if (updateConsuambles)
                    TempData["msg"] = $"Successfully Updated {ConsumableName}!";
                else
                    TempData["msg"] = "Unsuccessful!";
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Unsuccessfull!";
            }

            return RedirectToAction(nameof(Dashboard));
        }
        [HttpGet]
        public async Task<IActionResult> Order(int WardID)
        {
            var consumableManagerID = HttpContext.Session.GetInt32("ConsumableManagerID");
            if (consumableManagerID.HasValue)
            {
                var consumables = await _WCRepo.GetAllConsumablesAsync();
                var model = new PurchaseOrderViewModel
                {
                    WardID = WardID,
                    SupplierID = 1,
                    ConsumableManagerID = consumableManagerID.Value,
                    ConsumableOrders = consumables.Select(c => new ConsumableOrder
                    {
                        ConsumableID = c.ConsumableID,
                        ConsumableName = c.ConsumableName,
                        Quantity = null
                    }).ToList()
                };
                return View(model);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(PurchaseOrderViewModel purchaseorderviewmodel)
        {
            bool POD = false;
            bool PUWCS = false;
            int Q = 0;
            if (ModelState.IsValid)
            {
                foreach (var QCheck in purchaseorderviewmodel.ConsumableOrders)
                {
                    if(QCheck.Quantity == 0)
                    {
                        Q++;
                    }
                }
                if(Q == 3)
                {
                    TempData["msg"] = "No Quantity entered";
                    return View();
                }
                    var purchaseOrderID = await _WCRepo.AddPurchaseOrderAsync(purchaseorderviewmodel.SupplierID, purchaseorderviewmodel.ConsumableManagerID, purchaseorderviewmodel.WardID);
                foreach (var order in purchaseorderviewmodel.ConsumableOrders)
                {
                    POD = await _WCRepo.AddPurchaseOrderDetailAsync(purchaseOrderID, order.ConsumableID, order.Quantity ?? 0);
                    PUWCS = await _WCRepo.PurchaseUpdatetWardConsumableStock(purchaseorderviewmodel.WardID, order.ConsumableID, order.Quantity ?? 0);
                }
                if (POD && PUWCS == true)
                {
                    TempData["msg"] = $"Purchase Order Placed Successfully OrderID:{purchaseOrderID}";
                }
                else
                {
                    TempData["msg"] = "Failed to Place Order!";
                }
                return RedirectToAction("Dashboard");

            }
            return View(purchaseorderviewmodel);

        }

    }
}
