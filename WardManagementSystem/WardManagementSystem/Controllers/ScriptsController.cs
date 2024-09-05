using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class ScriptsController : Controller
    {
        private readonly IScriptDetailsRepo _SDRepo;
        public ScriptsController(IScriptDetailsRepo sDRepo)
        {
            _SDRepo = sDRepo;
        }
        public async Task<IActionResult> Dashboard()
        {
            //returns count for all scripts based on status
            var newcount = await _SDRepo.GetAllAsync('N');
            var processedcount = await _SDRepo.GetAllAsync('P');
            var receivedcount = await _SDRepo.GetAllAsync('R');

            var viewModel = new ScriptStatusCountViewModel
            {
                NewCount = newcount.Count(),
                ProcessedCount = processedcount.Count(),
                ReceivedCount = receivedcount.Count(),
            };
            return View(viewModel);
        }
        // returns a list of scripts based on the Status
        public async Task<IActionResult> DisplayScriptListN()
        {
            var scriptDetails = await _SDRepo.GetAllAsync('N');
            return View(scriptDetails);
        }
        public async Task<IActionResult> DisplayScriptListP()
        {
            var scriptDetails = await _SDRepo.GetAllAsync('P');
            return View(scriptDetails);
        }
        public async Task<IActionResult> DisplayScriptListR()
        {
            var scriptDetails = await _SDRepo.GetAllAsync('R');
            return View(scriptDetails);
        }
        // returns the details of each script based on Id
        public async Task<IActionResult> DetailsN(int id)
        {
            var script = await _SDRepo.GetByIdAsync(id);
            return View(script);
        }
        public async Task<IActionResult> DetailsP(int id)
        {
            var script = await _SDRepo.GetByIdAsync(id);
            return View(script);
        }
        public async Task<IActionResult> DetailsR(int id)
        {
            var script = await _SDRepo.GetByIdAsync(id);
            return View(script);
        }

        // Deals with sending the script to the pharmacy (Changes script status from N to P)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendScript(int Id)
        {
            try
            {
                var scriptDetails = new Script { ScriptID = Id };
                bool updateRecord = await _SDRepo.UpdateAsync(scriptDetails);
                if (updateRecord)
                {
                    TempData["msg"] = "Successfully Updated";
                }
                else
                {
                    TempData["msg"] = "Successfully failed";
                } 
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Successfully failed";
            }
            return RedirectToAction("Dashboard");
        }

    }
}
