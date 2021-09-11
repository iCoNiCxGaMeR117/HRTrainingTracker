using HRTrainingTracker.Entities;
using HRTrainingTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HRTrainingTracker.Controllers
{
    [Authorize(Roles = "Users")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HRTrainingContext _context;

        public HomeController(ILogger<HomeController> logger, HRTrainingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmployeeManager()
        {
            try
            {
                var Employees = _context.Employees
                    .Include(training => training.TrainingList)
                    .OrderBy(item => item.LastName)
                    .ToList();

                return View(Employees);
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
                var Trainings = _context.Trainings
                    .Include(employee => employee.Employees)
                    .OrderBy(item => item.TrainingName)
                    .ToList();

                return View(Trainings);
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
