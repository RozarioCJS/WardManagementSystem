using Microsoft.AspNetCore.Mvc;
using WardManagementSystem.Data.Models.Domain;
using WardManagementSystem.Data.Repository;

namespace WardManagementSystem.Controllers
{
    public class ScriptController : Controller
    {
        private readonly IScriptRepo _scriptRepo;
        public ScriptController(IScriptRepo scriptRepo)
        {
            _scriptRepo = scriptRepo;
        }

        public IActionResult Index()
        {
            return View();
        }


        //Display all
        public async Task<IActionResult> DisplayAll()
        {
            var scripts = await _scriptRepo.GetAllAsync();
            return View(scripts);
        }


        //add
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Script script)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(script);
                }

                bool addScript = await _scriptRepo.AddAsync(script);
                if (addScript)
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

            return RedirectToAction(nameof(DisplayAll));
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

                bool deleteScript = await _scriptRepo.DeleteAsync(id);
                if (deleteScript)
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
            var result = await _scriptRepo.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Script script)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(script);
                }

                bool updateScript = await _scriptRepo.UpdateAsync(script);
                if (updateScript)
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
