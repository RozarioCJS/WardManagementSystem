﻿using Microsoft.AspNetCore.Mvc;
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
            var conWards = await _WCRepo.GetAllAsync();
            return View(conWards);
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
        public async Task<IActionResult> UpdateStock(int WardID, int ConsumableID, int Quantity)
        {
            try
            {
                bool updateConsuambles = await _WCRepo.UpdateStockAsync(WardID, ConsumableID, Quantity);

                if (updateConsuambles)
                    TempData["msg"] = "Successfully Updated";
                else
                    TempData["msg"] = "Unsuccessfully";
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Unsuccessfull";
            }

            return RedirectToAction(nameof(Dashboard));
        }
        [HttpGet]
        public IActionResult Order(int WardID)
        {
            var model = new PurchaseOrderViewModel
            {
                WardID = WardID,
                SupplierID = 1,
                ConsumableManagerID = 2,
                ConsumableOrders = new List<ConsumableOrder>
                {
                    new ConsumableOrder{ConsumableID = 1, ConsumableName = "Gloves"},
                    new ConsumableOrder{ConsumableID = 2, ConsumableName = "Needles"},
                    new ConsumableOrder{ConsumableID = 3, ConsumableName = "Linen Savers"}
                }
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(PurchaseOrderViewModel purchaseorderviewmodel)
        {
            if (ModelState.IsValid)
            {
                var purchaseOrderID = await _WCRepo.AddPurchaseOrderAsync(purchaseorderviewmodel.SupplierID, purchaseorderviewmodel.ConsumableManagerID, purchaseorderviewmodel.WardID);
                foreach (var order in purchaseorderviewmodel.ConsumableOrders)
                {
                    await _WCRepo.AddPurchaseOrderDetailAsync(purchaseOrderID, order.ConsumableID, order.Quantity);
                    await _WCRepo.PurchaseUpdatetWardConsumableStock(purchaseorderviewmodel.WardID, order.ConsumableID, order.Quantity);
                }
                return RedirectToAction("Dashboard");
            }
            return View(purchaseorderviewmodel);

        }

    }
}
