using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using WardManagementSystem.Data.Repository;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

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
        public async Task<IActionResult> DisplayAll(int PatientFileID)
        {
            var temp = HttpContext.Session.GetString("DoctorID");   //retrieving doctorID from session.
            int doctorID = int.Parse(temp);

            //Filling viewdata for displaying specific patient's instructions
            var patientInstructions = await _patientInstructionRepo.GetAllPatientNameAsync(PatientFileID, doctorID);
            ViewData["PatientInstructionViewModel"] = patientInstructions;

            //Filling the drop down list with patient names
            var patientComboBox = await _patientInstructionRepo.GetPatientFullNameAsync();
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

            return View(patientInstructions.Where(x => x.PatientFileID == PatientFileID).Take(50));
        }


        //add
        public async Task<IActionResult> Add()
        {
            //filling the drop down list with patient names
            var patientFullName = await _patientInstructionRepo.GetPatientFullNameAsync();
            ViewData["PatientFileFullNameViewModel"] = patientFullName;

            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientFileFullNameViewModel p in patientFullName)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientFileID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var selectList = new SelectList(patients, "Value", "Text");
            ViewBag.SelectList = selectList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Patient_Instruction patient_instruction)
        {
            var temp = HttpContext.Session.GetString("DoctorID");
            int doctorID = int.Parse(temp);

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(patient_instruction);
                }

                bool addInstruction = await _patientInstructionRepo.AddAsync(patient_instruction, doctorID);

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

            return RedirectToRoute(new
            {
                controller = "PatientInstruction",
                action = "DisplayAll",
                id = patient_instruction.PatientFileID
            });
            //return RedirectToAction(nameof(DisplayAll));
            //return ControllerContext.MyDisplayRouteInfo(id, product.name);
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
            //filling the drop down list
            var patientFullName = await _patientInstructionRepo.GetPatientFullNameAsync();
            ViewData["PatientFileFullNameViewModel"] = patientFullName;

            List<SelectListItem> patients = new List<SelectListItem>();     //creating a list to store patients
            foreach (PatientFileFullNameViewModel p in patientFullName)        //iterating through the data to fill the list with patients
            {
                patients.Add(new SelectListItem { Value = p.PatientFileID.ToString(), Text = p.PatientName });
            }
            ViewBag.Patients = patients;        //Setting a ViewBag to contain the list of patients
            var selectList = new SelectList(patients, "Value", "Text");
            ViewBag.SelectList = selectList;

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
