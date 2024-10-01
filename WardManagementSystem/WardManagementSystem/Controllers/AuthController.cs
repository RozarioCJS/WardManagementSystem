using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.DiaSymReader;
using Microsoft.Extensions.Configuration;
using PatientCareSubsystem.UI.Models;
using System.Security.Cryptography;
using System.Text;

public class AuthController : Controller
{
    private readonly string connectionString;

    public AuthController(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("connectionString");
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = AuthenticateUser(username, password);
        if (user != null)
        {
            // Store user info in session or authentication cookie
            HttpContext.Session.SetString("UserRole", user.Role); // Assuming user has a Role property
            HttpContext.Session.SetString("UserName", user.Username);

            // Redirect to the respective dashboard
            if (user.Role == "Nurse")
            {
                return RedirectToAction("Dashboard", "Nurse");
            }
            else if (user.Role == "SisterNurse")
            {
                return RedirectToAction("Dashboard", "SisterNurse");
            }
            else if (user.Role == "Admin")
            {
                return RedirectToAction("Dashboard","Admin");
            }
            else if (user.Role == "Doctor")
            {
                return RedirectToAction("Dashboard", "Schedule");
            }
            else if (user.Role == "Consumable Manager")
            {
                return RedirectToAction("Dashboard", "Scripts");
            }
            else if (user.Role == "Script Manager")
            {
                return RedirectToAction("Dashboard", "Consumables");
            }
        }
        ModelState.AddModelError("", "Invalid username or password.");
        return View();
    }

    private LoginViewModel AuthenticateUser(string username, string password)
    {
        // Use Dapper to fetch user from the database and validate password
        using (var connection = new SqlConnection(connectionString))
        {
            var sql = "SELECT * FROM [User] WHERE Username = @UserName AND Password = @Password";
            var user = connection.QuerySingleOrDefault<LoginViewModel>(sql, new { UserName = username, Password = password });
            return user; // Ensure you securely handle passwords (use hashing)
        }
    }

}
