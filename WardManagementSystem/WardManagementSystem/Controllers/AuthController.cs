using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.DiaSymReader;
using Microsoft.Extensions.Configuration;
using PatientCareSubsystem.UI.Models;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

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
            HttpContext.Session.SetString("LastName", user.LastName);
            HttpContext.Session.SetInt32("ConsumableManagerID", user.ConsumableManagerID);
            HttpContext.Session.SetInt32("PrescriptionManagerID", user.PrescriptionManagerID);
            HttpContext.Session.SetInt32("AdminID", user.AdminID);
            HttpContext.Session.SetString("DoctorID", user.DoctorID.ToString());
            HttpContext.Session.SetString("WardAdminID", user.WardAdminID.ToString());

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
                return RedirectToAction("Dashboard", "Consumables");
            }
            else if (user.Role == "Script Manager")
            {
                return RedirectToAction("Dashboard", "Scripts");
            }
            else if (user.Role == "Ward Admin")
            {
                return RedirectToAction("DisplayAllAdmissions", "Admission");
            }
        }
        TempData["msg"] = "Invalid UserName or Password";
        return View();
    }

    private LoginViewModel AuthenticateUser(string username, string password)
    {
        // Use Dapper to fetch user from the database and validate password
        using (var connection = new SqlConnection(connectionString))
        {
            var sql = "SELECT u.UserName, u.Password, u.Role, d.DoctorID,cm.ConsumableManagerID, sm.PrescriptionManagerID, a.AdminID, wa.WardAdminID, d.LastName, cm.LastName, sm.LastName, a.LastName, wa.LastName FROM [User] AS u LEFT JOIN [DOCTOR] AS d ON u.UserID = d.UserID LEFT JOIN Consumable_Manager AS cm ON u.UserID = cm.UserID LEFT JOIN Prescription_Manager AS sm ON u.UserID = sm.UserID LEFT JOIN Admin AS a ON u.UserID = a.UserID LEFT JOIN Ward_Administrator AS wa ON u.UserID = wa.UserID WHERE Username = @UserName AND Password = @Password";
            var user = connection.QuerySingleOrDefault<LoginViewModel>(sql, new { UserName = username, Password = password });
            return user; // Ensure you securely handle passwords (use hashing)
        }
    }

}
