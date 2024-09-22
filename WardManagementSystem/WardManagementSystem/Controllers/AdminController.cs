using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using WardManagementSystem.Data.Repository;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace WardManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }

        //All of the below is Employee Management Related
        [HttpGet]
        public async Task<IActionResult> ManageEmployees()
        {
            var GetUsers = await _adminRepository.GetAllUserAsync();
            return View(GetUsers);
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeDetail(int Id)
        {
            var GetUsers = await _adminRepository.GetUserByIdAsync(Id);
            return View(GetUsers);
        }
        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            var roles = new List<string> { "Admin", "Doctor", "Consumable Manager", "Nurse", "Nursing Sister", "Prescription Manager", "Ward Admin" };
            ViewBag.Roles = roles;
            var usermodel = new UserViewModel();
            return View(usermodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(UserViewModel user)
        {
            var UserID = await _adminRepository.AddUserAsync(user.UserName, user.Password, user.Role);
            await _adminRepository.AddUserDetailsAsync(UserID, user.FirstName, user.LastName, user.ContactNumber, user.Email, user.Address1, user.Address2, user.Role);
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int Id)
        {
            var person = await _adminRepository.GetUserByIdAsync(Id);
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEmployee(int UserID, string ContactNumber, string Role)
        {

            try
            {
                if (!ModelState.IsValid)
                    return View();
                bool updateRecord = await _adminRepository.UpdateUserAsync(UserID, ContactNumber, Role);

                if (updateRecord)
                    TempData["msg"] = "Successful";
                else
                    TempData["msg"] = "Failed";
            }

            catch (Exception ex)
            {
                TempData["msg"] = "Error!";
            }
            return RedirectToAction(nameof(ManageEmployees));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var deleteResult = await _adminRepository.DeleteUserAsync(Id);
            return RedirectToAction(nameof(ManageEmployees));
        }

        //Ward Management Below

        [HttpGet]
        public async Task<IActionResult> ManageWards()
        {
            var GetUsers = await _adminRepository.GetAllWardAsync();
            return View(GetUsers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateWard(int WardID, string WardName)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                bool updateRecord = await _adminRepository.UpdateWardAsync(WardID, WardName);

                if (updateRecord)
                    TempData["msg"] = "Successful";
                else
                    TempData["msg"] = "Failed";
            }

            catch (Exception ex)
            {
                TempData["msg"] = "Error!";
            }
            return RedirectToAction(nameof(ManageWards));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteWard(int Id)
        {
            var deleteResult = await _adminRepository.DeleteWardAsync(Id);
            return RedirectToAction(nameof(ManageWards));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWard(Ward ward)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(ward);
                bool addPerson = await _adminRepository.AddWardAsync(ward);
                if (addPerson)
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
                TempData["msg"] = "Something went wrong!";
            }
            return RedirectToAction(nameof(ManageWards));
        }

        //Consumable Management Below

        [HttpGet]
        public async Task<IActionResult> ManageConsumables()
        {
            var GetCon = await _adminRepository.GetAllConsumablesAsync();
            return View(GetCon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateConsumables(int ConsumableID, string ConsumableName)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                bool updateRecord = await _adminRepository.UpdateConsumableAsync(ConsumableID, ConsumableName);

                if (updateRecord)
                    TempData["msg"] = "Successful";
                else
                    TempData["msg"] = "Failed";
            }

            catch (Exception ex)
            {
                TempData["msg"] = "Error!";
            }
            return RedirectToAction(nameof(ManageConsumables));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConsumables(int Id)
        {
            var deleteResult = await _adminRepository.DeleteConsumableAsync(Id);
            return RedirectToAction(nameof(ManageConsumables));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddConsumables(Consumable consumable)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(consumable);
                bool addPerson = await _adminRepository.AddConsumabledAsync(consumable);
                if (addPerson)
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
                TempData["msg"] = "Something went wrong!";
            }
            return RedirectToAction(nameof(ManageConsumables));
        }


        //Medication Management
        [HttpGet]
        public async Task<IActionResult> ManageMedications()
        {
            var GetMed = await _adminRepository.GetAllMedicationAsync();
            return View(GetMed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMedications(int MedicationID, string MedicationName)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                bool updateRecord = await _adminRepository.UpdateMedicationAsync(MedicationID, MedicationName);

                if (updateRecord)
                    TempData["msg"] = "Successful";
                else
                    TempData["msg"] = "Failed";
            }

            catch (Exception ex)
            {
                TempData["msg"] = "Error!";
            }
            return RedirectToAction(nameof(ManageMedications));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMedication(Medication medication)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(medication);
                bool addPerson = await _adminRepository.AddMedicationAsync(medication);
                if (addPerson)
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
                TempData["msg"] = "Something went wrong!";
            }
            return RedirectToAction(nameof(ManageMedications));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMedication(int Id)
        {
            var deleteResult = await _adminRepository.DeleteMedicationAsync(Id);
            return RedirectToAction(nameof(ManageMedications));
        }

        //AllergyManagement

        [HttpGet]
        public async Task<IActionResult> ManageAllergies()
        {
            var GetAl = await _adminRepository.GetAllAllergiesAsync();
            return View(GetAl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAllergy(int AllergyID, string AllergyName)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                bool updateRecord = await _adminRepository.UpdateAllergyAsync(AllergyID, AllergyName);

                if (updateRecord)
                    TempData["msg"] = "Successful";
                else
                    TempData["msg"] = "Failed";
            }

            catch (Exception ex)
            {
                TempData["msg"] = "Error!";
            }
            return RedirectToAction(nameof(ManageAllergies));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAllergy(Allergy allergy)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(allergy);
                bool addPerson = await _adminRepository.AddAllergyAsync(allergy);
                if (addPerson)
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
                TempData["msg"] = "Something went wrong!";
            }
            return RedirectToAction(nameof(ManageAllergies));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAllergy(int Id)
        {
            var deleteResult = await _adminRepository.DeleteAllergyAsync(Id);
            return RedirectToAction(nameof(ManageAllergies));
        }
        [HttpGet]
        public async Task<IActionResult> ManageConditions()
        {
            return View();
        }

    }
}
