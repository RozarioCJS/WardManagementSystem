using WardManagementSystem.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
   
{
    public class PatientsController : Controller 
    {
        private readonly IPatientRepository _patientRepository;
        
        public PatientsController (IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}
