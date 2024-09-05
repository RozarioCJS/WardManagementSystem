using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using System.Threading.Tasks;
using WardManagementSystem.Data.Respository;

namespace WardManagementSystem.Controllers
{
    public class NurseController : Controller
    {
        private readonly INurseRepository _nurseRepo;

        public NurseController(INurseRepository nurseRepo)
        {
            _nurseRepo = nurseRepo;
        }

        // Display the form to add a new nurse
        public IActionResult Add()
        {  
            return View();
        }

        // Process the form submission to add a new nurse
        [HttpPost]
        public async Task<IActionResult> Add(Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                var success = await _nurseRepo.AddAsync(nurse);
                if (success)
                {
                    return RedirectToAction(nameof(DisplayAll));
                }
                ModelState.AddModelError("", "Unable to add nurse. Please try again.");
            }
            return View(nurse);
        }

        // Display the form to edit an existing nurse
        public async Task<IActionResult> Edit(int id)
        {
            var nurse = await _nurseRepo.GetByIdAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }
            return View(nurse);
        }

        // Process the form submission to update an existing nurse
        [HttpPost]
        public async Task<IActionResult> Edit(Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                var success = await _nurseRepo.UpdateAsync(nurse);
                if (success)
                {
                    return RedirectToAction(nameof(DisplayAll));
                }
                ModelState.AddModelError("", "Unable to update nurse. Please try again.");
            }
            return View(nurse);
        }

        // Display a list of all nurses
        public async Task<IActionResult> DisplayAll()
        {
            var nurses = await _nurseRepo.GetAllAsync();
            return View(nurses);
        }

        // Process the deletion of a nurse
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _nurseRepo.DeleteAsync(id);
            if (!success)
            {
                ModelState.AddModelError("", "Unable to delete nurse. Please try again.");
            }
            return RedirectToAction(nameof(DisplayAll));
        }
    }
}
