using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.Design;
using WardManagementSystem.Data.Models;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
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
            //retrieve data from database
            var todayCount = await _scheduleRepo.GetAllTodayAsync(1);           //GetAllTodayAsync(DoctorID)
            var totalCount = await _scheduleRepo.GetAllTotalAsync(1);
            var schedules = await _scheduleRepo.GetDashboardAsync(1);

            //using ViewData to store the different data for different ViewModels
            ViewData["DoctorDashboardViewModel"] = schedules;
            ViewData["ScheduleCountViewModel"] = new ScheduleCountViewModel
            {
                //returns count for all scripts based on status
                TodayCount = todayCount.Count(),
                TotalCount = totalCount.Count(),
            };
            return View();
        }


        //Display all
        public async Task<IActionResult> DisplayAll(int PatientID)
        {
            var patientSchedules = await _scheduleRepo.GetAllPatientAsync(PatientID);
            ViewData["ScheduleDisplayViewModel"] = patientSchedules;

            //Searching for patient to be displayed
            var patientComboBox = await _scheduleRepo.GetPatientFullNameAsync();
            ViewData["PatientComboViewModel"] = patientComboBox;

            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientFullNameViewModel p in patientComboBox)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var selectList = new SelectList(patients, "Value", "Text");
            ViewBag.SelectList = selectList;

            if (!String.IsNullOrWhiteSpace(PatientID.ToString()))       //Find a way to display all schedules if no patient is selected.
            {
                return View();
            }

            return View(patientSchedules.Where(x => x.PatientID == PatientID).Take(50));
        }


        //add
        public async Task<IActionResult> Add()
        {
            //filling the drop down list
            var patientComboBox = await _scheduleRepo.GetPatientFullNameAsync();
            ViewData["PatientComboViewModel"] = patientComboBox;

            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientFullNameViewModel p in patientComboBox)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var selectList = new SelectList(patients, "Value", "Text");
            ViewBag.SelectList = selectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Schedule schedule)
        {
            // inserting the record
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
            //Searching for patient to be displayed
            var patientComboBox = await _scheduleRepo.GetPatientFullNameAsync();
            ViewData["PatientComboViewModel"] = patientComboBox;

            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientFullNameViewModel p in patientComboBox)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var selectList = new SelectList(patients, "Value", "Text");
            ViewBag.SelectList = selectList;

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
