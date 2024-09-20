using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class PatientInstructionController : Controller
    {
        private readonly IPatientInstructionRepo _patientInstructionRepo;
        public PatientInstructionController(IPatientInstructionRepo instructionRepo)
        {
            _patientInstructionRepo = instructionRepo;
        }

        public IActionResult Index()
        {
            return View();
        }


        //Display all
        public async Task<IActionResult> DisplayAll()
        {
            var patientInstructions = await _patientInstructionRepo.GetAllAsync();
            return View(patientInstructions);
        }


        //add
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Patient_Instruction patient_instruction)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(patient_instruction);
                }

                bool addInstruction = await _patientInstructionRepo.AddAsync(patient_instruction);
                if (addInstruction)
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
            //var employeeDelete = await _employeeRepository.DeleteAsync(id);
            //return RedirectToAction(nameof(DisplayAll));

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(id);
                }

                bool deleteInstruction = await _patientInstructionRepo.DeleteAsync(id);
                if (deleteInstruction)
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
            var result = await _patientInstructionRepo.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Patient_Instruction patient_instruction)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(patient_instruction);
                }

                bool updateInstruction = await _patientInstructionRepo.UpdateAsync(patient_instruction);
                if (updateInstruction)
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
