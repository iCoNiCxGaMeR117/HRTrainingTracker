using HRTrainingTracker.BusinessLayer;
using HRTrainingTracker.Entities;
using HRTrainingTracker.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTrainingTracker.FrontEnd.Controllers
{
    public class TrainingInsightsController : Controller
    {
        private readonly ILogger<TrainingInsightsController> _logger;
        private readonly EmployeeFunctions _empFunc;
        private readonly TrainingFunctions _trnFunc;

        public TrainingInsightsController(ILogger<TrainingInsightsController> logger, HRTrainingContext context)
        {
            _logger = logger;
            _empFunc = new EmployeeFunctions(context);
            _trnFunc = new TrainingFunctions(context);
        }

        #region Employee Endpoints
        public IActionResult NewEmployeeSaver(Employee NewEmployee)
        {
            try
            {
                var savedChanges = _empFunc.SaveEmployee(NewEmployee, User.Identity.Name.Split('\\')[1], true);

                if (!savedChanges)
                    TempData["Error"] = "No records were updated! Make sure it doesn't already exist!";

                return RedirectToAction("EmployeeManager", "Home");
            }
            catch
            {
                TempData["Error"] = "An Issue Occured! Could Not Access Database!";
                return RedirectToAction("EmployeeManagerAddNew");
            }
        }

        public IActionResult EditEmployee(int id)
        {
            try
            {
                var employee = _empFunc.GetEmployee(id);

                return View(employee);
            }
            catch
            {
                TempData["Error"] = "An Issue Occured! Could Not Access Database!";
                return RedirectToAction("EmployeeManager");
            }
        }

        public IActionResult EmployeeSaver(Employee EditedEmployee)
        {
            try
            {
                var savedChanges = _empFunc.SaveEmployee(EditedEmployee, User.Identity.Name.Split('\\')[1], false);

                if (!savedChanges)
                    TempData["Error"] = "No records were updated! Make sure it doesn't already exist!";

                return RedirectToAction("EmployeeManager", "Home");
            }
            catch
            {
                TempData["Error"] = "An Issue Occured! Could Not Access Database!";
                return RedirectToAction("EmployeeManagerAddNew");
            }
        }

        public IActionResult RetireEmployee(int id)
        {
            var savedChanges = _empFunc.RetireEmployee(id);

            if (!savedChanges)
                TempData["Error"] = "No records were updated! Make sure it doesn't already exist!";

            return RedirectToAction("EmployeeManager", "Home");
        }
        #endregion

        #region Training Endpoints
        public IActionResult TrainingManagerAddNew()
        {
            return View();
        }

        public IActionResult NewTrainingSaver(Training NewTraining)
        {
            var savedChanges = _trnFunc.SaveTraining(NewTraining, User.Identity.Name.Split('\\')[1], true);

            if (!savedChanges)
                TempData["Error"] = "No records were updated! Make sure it doesn't already exist!";

            return RedirectToAction("TrainingManager", "Home");
        }

        public IActionResult EditTraining(int id)
        {
            try
            {
                var training = _trnFunc.GetTrainingById(id);

                return View(training);
            }
            catch
            {
                TempData["Error"] = "An Issue Occured! Could Not Access Database!";
                return RedirectToAction("TrainingManager");
            }
        }

        public IActionResult TrainingSaver(Training EditedTraining)
        {
            var savedChanges = _trnFunc.SaveTraining(EditedTraining, User.Identity.Name.Split('\\')[1], false);

            if (!savedChanges)
                TempData["Error"] = "No records were updated! Make sure it doesn't already exist!";

            return RedirectToAction("TrainingManager", "Home");
        }

        public IActionResult RetireTraining(int id)
        {
            _trnFunc.RetireTraining(id);

            return RedirectToAction("TrainingManager", "Home");
        }

        public IActionResult AttachEmployeeToTraining(Training SelectedTraining, int emplId)
        {
            return View();
        }
        #endregion
    }
}
