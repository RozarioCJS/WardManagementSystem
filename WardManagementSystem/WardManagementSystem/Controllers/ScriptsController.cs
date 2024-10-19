using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Models;
using WardManagementSystem.Data.Repository;
using WardManagementSystem.Data.Models.Services;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace WardManagementSystem.Controllers
{
    public class ScriptsController : Controller
    {
        private readonly IScriptDetailsRepo _SDRepo;
        private readonly PDFService _pdfservice;
        public ScriptsController(IScriptDetailsRepo sDRepo, PDFService pdfservice)
        {
            _SDRepo = sDRepo;
            _pdfservice = pdfservice;
        }
        public async Task<IActionResult> PrintScript(int id)
        {
            ScriptDetailsViewModel scriptDetailsViewModel = await _SDRepo.GetByIdAsync(id);
            byte[] pdfBytes = _pdfservice.GeneratePDF(scriptDetailsViewModel);
            return File(pdfBytes, "application/pdf", "Prescription.pdf");
        }
        public async Task<IActionResult> Dashboard()
        {
            //returns count for all scripts based on status
            var prescriptionManagerID = HttpContext.Session.GetInt32("PrescriptionManagerID");
            int PMID = (int)prescriptionManagerID;
            var newcount = await _SDRepo.GetAllAsyncNew('N');
            var processedcount = await _SDRepo.GetAllAsync('P',prescriptionManagerID.Value);
            var receivedcount = await _SDRepo.GetAllAsync('R',prescriptionManagerID.Value);

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
            var scriptDetails = await _SDRepo.GetAllAsyncNew('N');
            return View(scriptDetails);
        }
        public async Task<IActionResult> DisplayScriptListP(DateTime? searchDate = null)
        {
            var prescriptionManagerID = HttpContext.Session.GetInt32("PrescriptionManagerID");
            if (searchDate.HasValue)
            {
                var scriptDetails = await _SDRepo.GetByDateAsync(searchDate.Value);
                return View(scriptDetails);
            }
            else
            {
                var scriptDetails = await _SDRepo.GetAllAsync('P', prescriptionManagerID.Value);
                return View(scriptDetails);
            }
        }
        public async Task<IActionResult> DisplayScriptListR()
        {
            var prescriptionManagerID = HttpContext.Session.GetInt32("PrescriptionManagerID");
            var scriptDetails = await _SDRepo.GetAllAsync('R', prescriptionManagerID.Value);
            return View(scriptDetails);
        }
        // returns the details of each script based on Id
        public async Task<IActionResult> DetailsN(int id)
        {
            var script = await _SDRepo.GetByIdAsyncNew(id);
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
            var prescriptionManagerID = HttpContext.Session.GetInt32("PrescriptionManagerID");
            try
            {
                var scriptDetails = new Script { ScriptID = Id, PrescriptionManagerID = prescriptionManagerID };
                bool updateRecord = await _SDRepo.UpdateAsync(scriptDetails);
                if (updateRecord)
                {
                    TempData["msg"] = "Script Sent Successfully";
                }
                else
                {
                    TempData["msg"] = "Script failed to Sent";
                } 
            }
            catch (Exception ex)
            {
                TempData["msg"] = "failed";
            }
            return RedirectToAction("Dashboard");
        }

        // Marks scripts as Received (Changes script status from P to )
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReceivedScripts(int Id)
        {
            var prescriptionManagerID = HttpContext.Session.GetInt32("PrescriptionManagerID");
            try
            {
                var scriptDetails = new Script { ScriptID = Id, PrescriptionManagerID = prescriptionManagerID };
                bool updateRecord = await _SDRepo.ReceivedScriptsAsync(scriptDetails);
                if (updateRecord)
                {
                    TempData["msg"] = "Script Medication Received";
                }
                else
                {
                    TempData["msg"] = "Script Status Updated failed";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "failed";
            }
            return RedirectToAction("Dashboard");
        }
    }
}
