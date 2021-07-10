using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTrainingTracker.FrontEnd.Controllers
{
    public class TrainingInsightsController : Controller
    {
        public IActionResult EmployeeManagerAddNew()
        {
            return View();
        }
    }
}
