using HRTrainingTracker.BusinessLayer;
using HRTrainingTracker.Entities;
using HRTrainingTracker.FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HRTrainingTracker.Controllers
{
    [Authorize(Roles = "Users")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeFunctions _emplFunc;
        private readonly TrainingFunctions _tranFunc;

        public HomeController(ILogger<HomeController> logger, HRTrainingContext context)
        {
            _logger = logger;
            _emplFunc = new EmployeeFunctions(context);
            _tranFunc = new TrainingFunctions(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmployeeManager()
        {
            try
            {
                return View(_emplFunc.InitializeEmployeesViewer());
            }
            catch
            {
                TempData["Error"] = "An Issue Occured! Could Not Access Database!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult TrainingManager()
        {
            try
            {
                return View(_tranFunc.InitializeTrainingsViewer());
            }
            catch
            {
                TempData["Error"] = "An Issue Occured! Could Not Access Database!";
                return RedirectToAction("Index");
            }


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
