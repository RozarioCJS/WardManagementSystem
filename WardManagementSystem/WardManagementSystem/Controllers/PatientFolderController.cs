using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using WardManagementSystem.Data.Repository;


namespace WardManagementSystem.Controllers
{
    public class PatientFolderController : Controller
    {

        private readonly IPatientFolderRepository _patientfolderRepo;

        public PatientFolderController(IPatientFolderRepository patientfolderRepo)
        {
            _patientfolderRepo = patientfolderRepo;
        }
        public async Task<IActionResult> AddPatientFolder()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddPatientFolder(PatientFolder patientfolder)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(patientfolder);
                bool addpatientfolder = await _patientfolderRepo.AddPatientFolderAsync(patientfolder);
                if (addpatientfolder)
                {
                    TempData["msg"] = "Sucessfully Added";
                }
                else
                {
                    TempData["msg"] = "Could not add";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong. Please try again";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeletePatientFolder(int id)
        {
            var Deletepatientpolder = await _patientfolderRepo.DeletePatientFolderAsync(id);
            return RedirectToAction(nameof(DisplayAllPatientFolder));
        }

        //Changes Made
        public async Task<IActionResult> UpdatePatientFolder(int id)
        {
            var patientFolder = await _patientfolderRepo.GetPatientFolderByIdAsync(id);

            if (patientFolder == null)
            {
                return NotFound();
            }


            var viewModel = new UpdatePatientFolderViewModel
            {
                PatientFileID = patientFolder.PatientFileID,
                PatientID = patientFolder.PatientID,
                ArrivalDate = patientFolder.ArrivalDate,
                BedID = patientFolder.BedID,
                WardID = patientFolder.WardID,
                AdmissionStatus = patientFolder.AdmissionStatus,
                DoctorName = patientFolder.DoctorName
            };

            return View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> UpdatePatientFolder(PatientFolder patientfolder)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(patientfolder);
                bool addadmission = await _patientfolderRepo.UpdatePatientFolderAsync(patientfolder);
                if (addadmission)
                {
                    TempData["msg"] = "Sucessfully Update";
                }
                else
                {
                    TempData["msg"] = "Could not update";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong. Please try again";
            }
            return RedirectToAction("DisplayAllPatientFolder");//Change made    
        }

        public async Task<IActionResult> DisplayAllPatientFolder()
        {
            var admission = await _patientfolderRepo.GetAllPatientFolderAsync();
            return View(admission);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
