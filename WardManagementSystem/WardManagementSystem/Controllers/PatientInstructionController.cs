using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class PatientInstructionController : Controller
    {
        private readonly IPatientInstructionRepo _instructionRepo;
        public PatientInstructionController(IPatientInstructionRepo instructionRepo)
        {
            _instructionRepo = instructionRepo;
        }

        public IActionResult Index()
        {
            return View();
        }


        //Display all
        public async Task<IActionResult> DisplayAll()
        {
            var patientInstructions = await _instructionRepo.GetAllAsync();
            return View(patientInstructions);
        }


        //add
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Patient_Instruction instruction)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(instruction);
                }

                bool addEmployee = await _instructionRepo.AddAsync(instruction);
                if (addEmployee)
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
    }
}
