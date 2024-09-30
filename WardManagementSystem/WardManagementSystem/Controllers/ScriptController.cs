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
            var scripts = await _scriptRepo.GetAllPatientAsync(PatientFileID);
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
        public async Task<IActionResult> Add()
        {
            //filling the drop down list with doctor names
            var doctorFullName = await _scriptRepo.GetDoctorFullNameAsync();
            ViewData["DoctorFullNameViewModel"] = doctorFullName;

            List<SelectListItem> doctors = new List<SelectListItem>();     //creating a list to store doctors
            foreach (DoctorFullNameViewModel d in doctorFullName)        //iterating through the data to fill the list with doctors
            {
                doctors.Add(new SelectListItem { Value = d.DoctorID.ToString(), Text = d.DoctorName });     //doctor gets added to the list
            }
            ViewBag.Doctor = doctors;        //Setting a ViewBag to contain the list of doctors
            var selectListDoctor = new SelectList(doctors, "Value", "Text");    //setting the format to be carrient to drop down list
            ViewBag.SelectListDoctor = selectListDoctor;       //Stores the data with the correct format to be used in view with drop down list


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
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(script);
                }

                bool addScript = await _scriptRepo.AddAsync(script);
                if (addScript)
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
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(id);
                }

                bool deleteScript = await _scriptRepo.DeleteAsync(id);
                if (deleteScript)
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
