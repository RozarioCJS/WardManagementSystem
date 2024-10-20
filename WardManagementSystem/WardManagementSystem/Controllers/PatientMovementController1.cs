using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Repository;
using WardManagementSystem.Data.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WardManagementSystem.Controllers
{
    public class PatientMovementController : Controller
    {
        private readonly IPatientMovementRepository _movementRepo;

        public PatientMovementController(IPatientMovementRepository movementRepo)
        {
            _movementRepo = movementRepo;
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
                    TempData["msg"] = "Patient has been transferred.";
                }
                else
                {
                    TempData["msg"] = "Could not transfer the patient.";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "An error occurred while transferring the patient.";
            }

            return RedirectToAction("DisplayPatientMovements", new { patientId });
        }


    }
}
