using Microsoft.AspNetCore.Mvc;
using System;
using WardManagementSystem.Data.Models;
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
        public async Task<IActionResult> Dashboard()
        {
            var conWards = await _WCRepo.GetAllAsync();
            return View(conWards);
        }

        public async Task<IActionResult> DetailsA(int Id)
        {
            var wardConsumables = await _WCRepo.GetByIdAsync(Id);
            return View("Details", wardConsumables);
        }
        public async Task<IActionResult> DetailsB(int Id)
        {
            var wardconsume = await _WCRepo.GetByIdAsync(Id);
            return View("Details", wardconsume);
        }
        public async Task<IActionResult> DetailsC(int Id)
        {
            var wardconsume = await _WCRepo.GetByIdAsync(Id);
            return View("Details", wardconsume);
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
                bool updateConsuambles = await _WCRepo.UpdateStockAsync( WardID,  ConsumableID,  Quantity);

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

    }
}
