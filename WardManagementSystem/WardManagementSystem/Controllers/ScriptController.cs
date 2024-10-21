using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class ScriptController : Controller
    {
        private readonly IScriptRepo _scriptRepo;
        public ScriptController(IScriptRepo scriptRepo)
        {
            _scriptRepo = scriptRepo;
        }

        public IActionResult Index()
        {
            return View();
        }


        //Display all
        public async Task<IActionResult> DisplayAll(int PatientFileID)
        {
            var temp = HttpContext.Session.GetString("DoctorID");   //retrieving doctorID from session.
            int doctorID = int.Parse(temp);

            var scripts = await _scriptRepo.GetAllPatientAsync(PatientFileID, doctorID);
            ViewData["PatientScriptViewModel"] = scripts;

            //Searching for patient to be displayed
            var patientComboBox = await _scriptRepo.GetPatientFullNameAsync();
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

            return View(scripts.Where(x => x.PatientFileID == PatientFileID).Take(50));
        }


        //add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //filling the drop down list (patient full name)
            var patientFullName = await _scriptRepo.GetPatientFullNameAsync();
            ViewData["PatientFileFullNameViewModel"] = patientFullName;

            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientFileFullNameViewModel p in patientFullName)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientFileID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var patientList = new SelectList(patients, "Value", "Text");
            ViewBag.PatientList = patientList;

            //filling the drop down list (medication name)
            var medication = await _scriptRepo.GetMedicationNameAsync();
            ViewData["MedicationNameViewModel"] = medication;

            List<SelectListItem> medications = new List<SelectListItem>();     //creating a list to store patients
            foreach (MedicationNameViewModel m in medication)        //iterating through the data to fill the list with patients
            {
                medications.Add(new SelectListItem { Value = m.MedicationID.ToString(), Text = m.MedicationName });
            }
            ViewBag.Medication = medications;        //Setting a ViewBag to contain the list of medications
            var medicationList = new SelectList(medications, "Value", "Text");
            ViewBag.MedicationList = medicationList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Script script)
        {
            var temp = HttpContext.Session.GetString("DoctorID");
            int doctorID = int.Parse(temp);

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(script);
                }

                bool addScript = await _scriptRepo.AddAsync(script, doctorID);
                if (addScript)
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

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(id);
                }

                bool deleteScript = await _scriptRepo.DeleteAsync(id);
                if (deleteScript)
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

        //edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //filling the drop down list (medication name)
            var medication = await _scriptRepo.GetMedicationNameAsync();
            ViewData["MedicationNameViewModel"] = medication;

            List<SelectListItem> medications = new List<SelectListItem>();     //creating a list to store patients
            foreach (MedicationNameViewModel m in medication)        //iterating through the data to fill the list with patients
            {
                medications.Add(new SelectListItem { Value = m.MedicationID.ToString(), Text = m.MedicationName });
            }
            ViewBag.Medication = medications;        //Setting a ViewBag to contain the list of medications
            var medicationList = new SelectList(medications, "Value", "Text");
            ViewBag.MedicationList = medicationList;

            //filling the relevant controls
            var result = await _scriptRepo.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Script script)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(script);
                }

                bool updateScript = await _scriptRepo.UpdateAsync(script);
                if (updateScript)
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
    }
}
