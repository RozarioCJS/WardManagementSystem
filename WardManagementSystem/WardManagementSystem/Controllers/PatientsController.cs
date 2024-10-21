using WardManagementSystem.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Repository;
using WardManagementSystem.Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WardManagementSystem.Controllers

{
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepo;

        public PatientsController(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }

        [HttpGet]
        public async Task<IActionResult> AddPatient()
        {
            ////filling the drop down list
            //var allergyName = await _patientRepo.GetAllergyName();
            //ViewData["AllergyNameViewModel"] = allergyName;

            //List<SelectListItem> allergy = new List<SelectListItem>();     //creating a list to store patients
            //foreach (AllergyNameViewModel a in allergyName)        //iterating through the data to fill the list with patients
            //{
            //    allergy.Add(new SelectListItem { Value = a.AllergyId.ToString(), Text =a.AllergyName });
            //}
            //ViewBag.Allergy = allergy;        //Setting a ViewBag to contain the list of patients
            //var selectListAllergy = new SelectList(allergy, "Value", "Text");
            //ViewBag.SelectListAllergy = selectListAllergy;

            //filling the drop down list
            var allergyFullName = await _patientRepo.GetAllergyName();
            ViewData["AllergyNameViewModel"] = allergyFullName;

            List<SelectListItem> allergies = new List<SelectListItem>();     //creating a list to store patients
            foreach (AllergyNameViewModel a in allergyFullName)        //iterating through the data to fill the list with patients
            {
                allergies.Add(new SelectListItem { Value = a.AllergyId.ToString(), Text = a.AllergyName });
            }
            ViewBag.Allergies = allergies;        //Setting a ViewBag to contain the list of patients
            var selectListAllergy = new SelectList(allergies, "Value", "Text");
            ViewBag.SelectListAllergy = selectListAllergy;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(patient);
                }

                bool addPatientSuccess = await _patientRepo.AddPatientAsync(patient);
                if (addPatientSuccess)
                {
                    TempData["msg"] = "Patient successfully added.";
                }
                else
                {
                    TempData["msg"] = "Failed to add patient.";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "An error occurred while adding the patient. Please try again.";
            }

            return RedirectToAction(nameof(DisplayAllPatients));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                bool deletePatient = await _patientRepo.DeletePatientAsync(id);
                TempData["msg"] = deletePatient ? "Successfully deleted patient." : "Could not delete patient.";
            }
            catch (Exception ex)
            {

                TempData["msg"] = "An error occurred while deleting the patient.";
            }

            return RedirectToAction(nameof(DisplayAllPatients));
        }

        //[HttpPost]
        //public async Task<IActionResult> DeletePatient(int id)
        //{
        //    var Deletepatient = await _patientRepo.DeletePatientAsync(id);
        //    return RedirectToAction(nameof(DisplayAllPatients));
        //}


        [HttpGet]
        public async Task<IActionResult> UpdatePatient(int id)
        {

            //filling the drop down list
            var allergyName = await _patientRepo.GetAllergyName();
            ViewData["AllergyNameViewModel"] = allergyName;

            List<SelectListItem> allergy = new List<SelectListItem>();     //creating a list to store patients
            foreach (AllergyNameViewModel a in allergyName)        //iterating through the data to fill the list with patients
            {
                allergy.Add(new SelectListItem { Value = a.AllergyId.ToString(), Text = a.AllergyName });
            }
            ViewBag.Allergy = allergy;        //Setting a ViewBag to contain the list of patients
            var selectListAllergy = new SelectList(allergy, "Value", "Text");
            ViewBag.SelectListAllergy = selectListAllergy;

            var patient = await _patientRepo.GetPatientByIdAsync(id);
            if (patient == null)
            {
                TempData["msg"] = "Patient not found.";
                return RedirectToAction(nameof(DisplayAllPatients));
            }

            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatient(Patient patient)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(patient);
                bool addpatient = await _patientRepo.UpdatePatientAsync(patient);
                if (addpatient)
                {
                    TempData["msg"] = "Sucessfully Updated";
                }
                else
                {
                    TempData["msg"] = "Could not update patient information";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong. Please try again";
            }
            return RedirectToAction(nameof(DisplayAllPatients));
        }


        public async Task<IActionResult> DisplayAllPatients()
        {
            var patientsinfo = await _patientRepo.GetPatientInfo();
            //ViewData["PatientsDisplayViewModel"] = patientsinfo;
            // Map to the view model
            //var patientViewModels = patients.Select(p => new PatientsDisplayViewModel
            //{
            //    PatientID = p.PatientId,
            //    FirstName = p.FirstName,
            //    LastName = p.LastName,
            //    ContactNumber = p.ContactNumber,
            //    Address1 = p.Address1,
            //    Address2 = p.Address2,
            //   // AllergyName = AllergyName 
            //}).ToList();

            return View(patientsinfo);
        }
         public async Task<IActionResult> PatientListView()
        {
            var patientsinfo = await _patientRepo.GetPatientListAsync();
            return View(patientsinfo);
        }



        public IActionResult Index()
        {
            return View();
        }


    }
}