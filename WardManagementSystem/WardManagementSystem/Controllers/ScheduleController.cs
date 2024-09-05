using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepo _scheduleRepo;
        public ScheduleController(IScheduleRepo scheduleRepo)
        {
            _scheduleRepo = scheduleRepo;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Dashboard()            //should be Dashboard(int DoctorID)
        {
            //returns count for all scripts based on status
            var todayCount = await _scheduleRepo.GetAllTodayAsync(0);           //GetAllTodayAsync(DoctorID)
            var totalCount = await _scheduleRepo.GetAllTotalAsync(0);

            var viewModel = new ScheduleCountViewModel
            {
                TodayCount = todayCount.Count(),
                TotalCount = totalCount.Count(),
            };
            return View(viewModel);
        }



        //Display all
        public async Task<IActionResult> DisplayAll()
        {
            var schedules = await _scheduleRepo.GetAllAsync();
            return View(schedules);
        }


        //add
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Schedule schedule)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(schedule);
                }

                bool addSchedule = await _scheduleRepo.AddAsync(schedule);
                if (addSchedule)
                {
                    TempData["msg"] = "Successfully Added!";
                }
                else
                {
                    TempData["msg"] = "Could not add.";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong!";
            }

            return RedirectToAction(nameof(DisplayAll));
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            //var employeeDelete = await _employeeRepository.DeleteAsync(id);
            //return RedirectToAction(nameof(DisplayAll));

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(id);
                }

                bool deleteSchedule = await _scheduleRepo.DeleteAsync(id);
                if (deleteSchedule)
                {
                    TempData["msg"] = "Successfully Deleted!";
                }
                else
                {
                    TempData["msg"] = "Could not delete.";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong!";
            }

            return RedirectToAction(nameof(DisplayAll));
        }

        //edit
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _scheduleRepo.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Schedule schedule)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(schedule);
                }

                bool updateSchedule = await _scheduleRepo.UpdateAsync(schedule);
                if (updateSchedule)
                {
                    TempData["msg"] = "Successfully Updated!";
                }
                else
                {
                    TempData["msg"] = "Could not update.";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong!";
            }

            return RedirectToAction(nameof(DisplayAll));
        }
    }
}
