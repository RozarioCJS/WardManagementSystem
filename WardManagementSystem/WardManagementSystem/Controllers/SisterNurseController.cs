using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class SisterNurseController : Controller
    {
        private readonly ISisterNurseRepository _sisterNurseRepo;

        public SisterNurseController(ISisterNurseRepository sisterNurseRepo)
        {
            _sisterNurseRepo = sisterNurseRepo;
        }

        public async Task<IActionResult> Dashboard()
        {
            // Fetch data relevant for the dashboard (e.g., tasks, statistics)
            var tasks = await _sisterNurseRepo.GetTasksAsync(); // Assuming this method exists
            var model = new SisterNurseDashboardViewModel
            {
                Tasks = tasks
            };
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SisterNurse sisterNurse)
        {
            if (!ModelState.IsValid)
            {
                return View(sisterNurse);
            }

            var result = await _sisterNurseRepo.AddAsync(sisterNurse);
            if (result)
            {
                return RedirectToAction(nameof(DisplayAll));
            }

            ModelState.AddModelError("", "Error adding Sister Nurse.");
            return View(sisterNurse);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var sisterNurse = await _sisterNurseRepo.GetByIdAsync(id);
            if (sisterNurse == null)
            {
                return NotFound();
            }
            return View(sisterNurse);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SisterNurse sisterNurse)
        {
            if (!ModelState.IsValid)
            {
                return View(sisterNurse);
            }

            var result = await _sisterNurseRepo.UpdateAsync(sisterNurse);
            if (result)
            {
                return RedirectToAction(nameof(DisplayAll));
            }

            ModelState.AddModelError("", "Error updating Sister Nurse.");
            return View(sisterNurse);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var sisterNurse = await _sisterNurseRepo.GetByIdAsync(id);
            if (sisterNurse == null)
            {
                return NotFound();
            }
            return View(sisterNurse);
        }

        public async Task<IActionResult> DisplayAll()
        {
            var sisterNurses = await _sisterNurseRepo.GetAllAsync();
            return View(sisterNurses);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sisterNurseRepo.DeleteAsync(id);
            if (result)
            {
                return RedirectToAction(nameof(DisplayAll));
            }
            return NotFound();
        }
    }
}
