using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class VisitController : Controller
    {
        private readonly IVisitRepo _visitRepo;
        public VisitController(IVisitRepo visitRepo)
        {
            _visitRepo = visitRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Display all
        public async Task<IActionResult> DisplayAll(int PatientFileID)
        {
            var temp = HttpContext.Session.GetString("DoctorID");
            int doctorID = int.Parse(temp);

            var patientVisits = await _visitRepo.GetAllAsync(PatientFileID, doctorID);
            ViewData["VisitNoteViewModel"] = patientVisits;

            //Searching for patient to be displayed
            var patientComboBox = await _visitRepo.GetPatientFileFullNameAsync();
            ViewData["PatientFileComboViewModel"] = patientComboBox;

            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientFileFullNameViewModel p in patientComboBox)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientFileID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var selectList = new SelectList(patients, "Value", "Text");
            ViewBag.SelectList = selectList;

            if (!String.IsNullOrWhiteSpace(PatientFileID.ToString()))
            {
                return View();
            }

            return View(patientVisits.Where(x => x.PatientFileID == PatientFileID).Take(50));
        }



        //add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //filling the drop down list for patient name
            var patientFullName = await _visitRepo.GetPatientFileFullNameAsync();
            ViewData["PatientFileFullNameViewModel"] = patientFullName;

            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientFileFullNameViewModel p in patientFullName)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientFileID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var selectList = new SelectList(patients, "Value", "Text");
            ViewBag.SelectList = selectList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Visit visit)
        {
            var temp = HttpContext.Session.GetString("DoctorID");
            int doctorID = int.Parse(temp);

            // inserting the record
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(visit);
                }

                bool addVisit = await _visitRepo.AddAsync(visit, doctorID);
                if (addVisit)
                {
                    TempData["msg"] = "Successfully Added! Please select patient to view the addition.";
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

        //edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //filling the drop down list
            var patientFullName = await _visitRepo.GetPatientFileFullNameAsync();
            ViewData["PatientFileFullNameViewModel"] = patientFullName;

            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientFileFullNameViewModel p in patientFullName)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientFileID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var selectList = new SelectList(patients, "Value", "Text");
            ViewBag.SelectList = selectList;

            //filling rest of the controls
            var result = await _visitRepo.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Visit visit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(_visitRepo);
                }

                bool updateVisit = await _visitRepo.UpdateAsync(visit);
                if (updateVisit)
                {
                    TempData["msg"] = "Successfully Updated! Please select patient to view the update.";
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


        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(id);
                }

                bool deleteVisitNote = await _visitRepo.DeleteAsync(id);
                if (deleteVisitNote)
                {
                    TempData["msg"] = "Successfully Deleted! Please select patient to view the deletion.";
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
    }
}
