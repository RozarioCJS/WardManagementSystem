using Microsoft.AspNetCore.Mvc;
using System;
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







        [HttpGet]
        public async Task<IActionResult> ManageWards()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ManageConsumables()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ManageMedications()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ManageAllergies()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ManageConditions()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            return View();  
        }
    }
}
