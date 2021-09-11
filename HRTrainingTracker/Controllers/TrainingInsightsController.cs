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
        private readonly HRTrainingContext _context;

        public TrainingInsightsController(ILogger<TrainingInsightsController> logger, HRTrainingContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult EmployeeManagerAddNew()
        {
            try
            {
                var newEmployee = new Employee
                {
                    ShiftList = _context.Shifts.OrderBy(obj => obj.Name).ShiftSelectList(),
                    DeptList = _context.Departments.OrderBy(obj => obj.Name).DeptSelectList(),
                    BuildingList = _context.Buildings.OrderBy(obj => obj.Name).BuildingSelectList()
                };

                return View(newEmployee);
            }
            catch
            {
                TempData["Error"] = "An Issue Occured! Could Not Access Database!";
                return RedirectToAction("EmployeeManager", "Home");
            }
        }

        public IActionResult NewEmployeeSaver(Employee NewEmployee)
        {
            try
            {
                NewEmployee.Building = _context.Buildings.FirstOrDefault(obj => obj.BuildingID.Equals(NewEmployee.Building.BuildingID));
                NewEmployee.Department = _context.Departments.FirstOrDefault(obj => obj.DepartmentID.Equals(NewEmployee.Department.DepartmentID));
                NewEmployee.Shift = _context.Shifts.FirstOrDefault(obj => obj.ShiftID.Equals(NewEmployee.Shift.ShiftID));

                NewEmployee.CreatedByName = User.Identity.Name.Split('\\')[1];
                NewEmployee.CreatedDate = DateTime.Now;

                _context.Employees.Add(NewEmployee);

                _context.SaveChanges();

                return RedirectToAction("EmployeeManager", "Home");
            }
            catch
            {
                TempData["Error"] = "An Issue Occured! Could Not Access Database!";
                return RedirectToAction("EmployeeManagerAddNew");
            }
        }
    }
}
