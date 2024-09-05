using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using System.Threading.Tasks;
using WardManagementSystem.Data.Respository;

namespace WardManagementSystem.Controllers
{
    public class NurseScheduleController : Controller
    {
        private readonly INurseScheduleRepository _nurseScheduleRepo;

        public NurseScheduleController(INurseScheduleRepository nurseScheduleRepo)
        {
            _nurseScheduleRepo = nurseScheduleRepo;
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(NurseSchedule nurseSchedule)
        {
            if (ModelState.IsValid)
            {
                var result = await _nurseScheduleRepo.AddAsync(nurseSchedule);
                if (result) return RedirectToAction("DisplayAll");
            }
            return View(nurseSchedule);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var schedule = await _nurseScheduleRepo.GetByIdAsync(id);
            if (schedule == null) return NotFound();
            return View(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NurseSchedule nurseSchedule)
        {
            if (ModelState.IsValid)
            {
                var result = await _nurseScheduleRepo.UpdateAsync(nurseSchedule);
                if (result) return RedirectToAction("DisplayAll");
            }
            return View(nurseSchedule);
        }

        public async Task<IActionResult> DisplayAll()
        {
            var schedules = await _nurseScheduleRepo.GetAllAsync();
            return View(schedules);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _nurseScheduleRepo.DeleteAsync(id);
            return RedirectToAction("DisplayAll");
        }
    }
}
