using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class BedsController : Controller
    {
        private readonly IBedsRepository _bedsRepo;

        public BedsController(IBedsRepository bedsRepo)
        {
            _bedsRepo = bedsRepo;
        }
        public async Task<IActionResult> AddBeds()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBeds(Beds bed) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(bed);
                bool addPerson = await _bedsRepo.AddBedsAsync(bed); 
                if (addPerson)
                {
                    TempData["msg"] = "Successfully Added"; 
                }
                else
                {
                    TempData["msg"] = "Could not add";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong. Please try again";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBeds(int id)
        {
            var deleteBeds = await _bedsRepo.DeleteBedsAsync(id);
            return RedirectToAction(nameof(DisplayAllBeds));
        }

        public async Task<IActionResult> UpdateBeds(int id)
        {
            var bed = await _bedsRepo.GetBedsByIdAsync(id); 
            return View(bed);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBeds(Beds bed) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(bed);
                bool updated = await _bedsRepo.UpdateBedsAsync(bed);
                if (updated)
                {
                    TempData["msg"] = "Successfully Updated"; 
                }
                else
                {
                    TempData["msg"] = "Could not update";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong. Please try again";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DisplayAllBeds()
        {
            var beds = await _bedsRepo.GetAllBedsAsync(); 
            return View(beds);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
