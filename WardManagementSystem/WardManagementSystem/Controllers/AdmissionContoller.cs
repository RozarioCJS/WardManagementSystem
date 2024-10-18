using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.ViewModels;
using System;
using System.Threading.Tasks;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Repository;

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
