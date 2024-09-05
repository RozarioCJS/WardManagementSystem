using Microsoft.AspNetCore.Mvc;
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
        // GET: ConsumablesController
        public async Task<IActionResult> Dashboard()
        {
            var conWards = await _WCRepo.GetAllAsync();
            return View(conWards);
        }

        // GET: ConsumablesController/Details/5
        public async Task<IActionResult> DetailsA(int Id)
        {
            var wardconsume = await _WCRepo.GetByIdAsync(1);
            ViewBag.Wards = wardconsume;
            return View("Details", wardconsume);
        }
        public async Task<IActionResult> DetailsB(int Id)
        {
            var wardconsume = await _WCRepo.GetByIdAsync(2);
            ViewBag.Wards = wardconsume;
            return View("Details", wardconsume);
        }
        public async Task<IActionResult> DetailsC(int Id)
        {
            var wardconsume = await _WCRepo.GetByIdAsync(3);
            ViewBag.Wards = wardconsume;
            return View("Details", wardconsume);
        }

        public async Task<IActionResult> CreateOrder()
        {
            return RedirectToAction("Dashboard");
        }


    }
}
