using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Repository;
using WardManagementSystem.Data.Models.Domain;

namespace WardManagementSystem.Controllers
{
    public class PatientMovementController : Controller
    {
        private readonly IPatientMovementRepository _movementRepo;
        private readonly IPatientFolderRepository _patientfolderRepo;

        public PatientMovementController(IPatientMovementRepository movementRepo, IPatientFolderRepository patientfolderRepo)
        {
            _movementRepo = movementRepo;
            _patientfolderRepo = patientfolderRepo;
        }

        public async Task<IActionResult> MovePatient(int patientId, int wardId, int bedId)
        {
            try
            {
                var movement = new Movement
                {
                    PatientId = patientId,
                    WardId = wardId,
                    BedId = bedId,
                    DateTime = DateTime.Now,
                    Location = $"Moved to Ward {wardId}"
                };

                bool moveSuccess = await _movementRepo.AddMovementAsync(movement);

                if (moveSuccess)
                {
                    var patientFolder = await _patientfolderRepo.GetPatientFolderByIdAsync(patientId);
                    if (patientFolder != null)
                    {
                        patientFolder.WardID = wardId;
                        patientFolder.BedID = bedId;
                        await _patientfolderRepo.UpdatePatientFolderAsync(patientFolder);
                    }
                    TempData["msg"] = "Patient moved and folder updated successfully.";
                }
                else
                {
                    TempData["msg"] = "Could not move patient.";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "An error occurred while moving the patient.";
            }

            return RedirectToAction("DisplayPatientMovements", new { patientId });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
