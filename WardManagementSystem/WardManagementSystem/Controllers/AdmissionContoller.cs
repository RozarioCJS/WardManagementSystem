using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.ViewModels;
using System;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WardManagementSystem.Controllers
{
    public class AdmissionController : Controller
    {
        private readonly IAdmissionRepository _admissionRepo;
       

        public AdmissionController(IAdmissionRepository admissionRepo)
        {
            _admissionRepo = admissionRepo;
        }
        [HttpGet]
        public async Task<IActionResult> AddAdmission()
        {
            //filling the drop down list with doctor names
            var doctorFullName = await _admissionRepo.GetDoctorFullNameAsync();
            ViewData["DoctorFullNameViewModel"] = doctorFullName;

            List<SelectListItem> doctors = new List<SelectListItem>();     //creating a list to store doctors
            foreach (DoctorFullNameViewModel d in doctorFullName)        //iterating through the data to fill the list with doctors
            {
                doctors.Add(new SelectListItem { Value = d.DoctorID.ToString(), Text = d.DoctorName });     //doctor gets added to the list
            }
            ViewBag.Doctor = doctors;        //Setting a ViewBag to contain the list of doctors
            var selectListDoctor = new SelectList(doctors, "Value", "Text");    //setting the format to be carrient to drop down list
            ViewBag.SelectListDoctor = selectListDoctor;       //Stores the data with the correct format to be used in view with drop down list


            //filling the drop down list
            var patientComboBox = await _admissionRepo.GetPatientFullNameAsync();
            ViewData["PatientComboViewModel"] = patientComboBox;

            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientFullNameViewModel p in patientComboBox)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var selectList = new SelectList(patients, "Value", "Text");
            ViewBag.SelectList = selectList;


            //filling the drop down list
            var wardFullName = await _admissionRepo.GetWardFullNameAsync();
            ViewData["WardFullNameViewModel"] = wardFullName;

            List<SelectListItem> wards = new List<SelectListItem>();     //creating a list to store patients
            foreach (WardFullNameViewModel w in wardFullName)        //iterating through the data to fill the list with patients
            {
                wards.Add(new SelectListItem { Value = w.WardId.ToString(), Text = w.WardName });
            }
            ViewBag.Wards = wards;        //Setting a ViewBag to contain the list of patients
            var selectListWard = new SelectList(wards, "Value", "Text");
            ViewBag.SelectListWard = selectListWard;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmission(Admission admission) 
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(admission);

                
                bool admitted = await _admissionRepo.AddAdmissionAsync(admission);


                //var patientFolder = await _patientFolderRepo.GetPatientFolderByIdAsync(admission.FirstName);
                //patientFolder.WardID = admission.WardName;
                //patientFolder.Status = "Admitted";

                //await _patientFolderRepo.UpdatePatientFolderAsync(patientFolder);

                TempData["msg"] = admitted ? "Patient successfully admitted." : "Failed to admit patient.";
            }
            catch (Exception ex)
            {
                TempData["msg"] = "An error occurred while admitting the patient.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAdmission(int id)
        {
            await _admissionRepo.DeleteAdmissionAsync(id);
            return RedirectToAction(nameof(DisplayAllAdmissions));
        }

        public async Task<IActionResult> UpdateAdmission(int id)
        {
            var admission = await _admissionRepo.GetAdmissionByIdAsync(id);
            return View(admission);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdmission(AdmissionsViewModel admission)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(admission);
                bool updateAdmission = await _admissionRepo.UpdateAdmissionAsync(admission);
                TempData["msg"] = updateAdmission ? "Successfully Updated" : "Could not update";
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong. Please try again";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DisplayAllAdmissions()
        {
            var admission = await _admissionRepo.GetAllAdmissionAsync();
            return View(admission);
        }
    }
}
