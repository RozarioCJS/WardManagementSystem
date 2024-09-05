using Microsoft.AspNetCore.Mvc;

namespace WardManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
