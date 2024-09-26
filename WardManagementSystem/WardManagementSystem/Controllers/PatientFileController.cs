using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.Design;
using WardManagementSystem.Data.Models;
using WardManagementSystem.Data.Models.ViewModels;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class PatientFileController : Controller
    {
        private readonly IPatientFileRepo _patientFileRepo;
        public PatientFileController(IPatientFileRepo patientFileRepo)
        {
            _patientFileRepo = patientFileRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Display all Patient Files
        public async Task<IActionResult> DisplayAll(int PatientID)
        {
            //calling all the data for the ViewModels
            var patientFile = await _patientFileRepo.DisplayAllPatientFileAsync(PatientID);
            var patientCondition = await _patientFileRepo.DisplayAllChronicConditionAsync(PatientID);
            var patientAllergy = await _patientFileRepo.DisplayAllPatientAllergyAsync(PatientID);
            var patientMedication = await _patientFileRepo.DisplayAllPatientMedicationAsync(PatientID);
            var patientTreatment = await _patientFileRepo.DisplayAllPatientTreatmentAsync(PatientID);
            var patientVitals = await _patientFileRepo.DisplayAllPatientVitalsAsync(PatientID);

            //Creating ViewData to use the multiple ViewModels in the view
            ViewData["PatientFileViewModel"] = patientFile;
            ViewData["PatientChronicConditionViewModel"] = patientCondition;
            ViewData["PatientAllergyViewModel"] = patientAllergy;
            ViewData["PatientMedicationViewModel"] = patientMedication;
            ViewData["PatientTreatmentViewModel"] = patientTreatment;
            ViewData["PatientVitalsViewModel"] = patientVitals;
            

            //Searching for patient to be displayed
            var patientComboBox = await _patientFileRepo.GetPatientFullNameAsync();
            ViewData["PatientComboViewModel"] = patientComboBox;
            
            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientComboViewModel p in patientComboBox)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var selectList = new SelectList(patients, "Value", "Text");
            ViewBag.SelectList = selectList;

            if (!String.IsNullOrWhiteSpace(PatientID.ToString()))
            {
                return View();
            }

            return View();
        }
    }
}
