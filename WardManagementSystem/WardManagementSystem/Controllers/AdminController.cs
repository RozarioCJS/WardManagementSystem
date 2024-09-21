using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models.ViewModels;
using WardManagementSystem.Data.Repository;

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
