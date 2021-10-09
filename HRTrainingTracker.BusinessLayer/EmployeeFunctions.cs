using HRTrainingTracker.Entities;
using HRTrainingTracker.Entities.Models;
using HRTrainingTracker.Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.BusinessLayer
{
    public class EmployeeFunctions
    {
        private readonly HRTrainingContext _context;

        public EmployeeFunctions(HRTrainingContext context)
        {
            _context = context;
        }

        public EmployeesViewerModel InitializeEmployeesViewer()
        {
            return new EmployeesViewerModel
            {
                Employees = BuildEmployeeListing(),
                NewEmployee = NewEmployeeBuilding()
            };
        }

        public IList<Employee> BuildEmployeeListing()
        {
            try
            {
                return _context.Employees
                    .Include(training => training.TrainingList)
                    .Include(shift => shift.Shift)
                    .Include(building => building.Building)
                    .Include(dept => dept.Department)
                    .OrderBy(item => item.LastName)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public Employee NewEmployeeBuilding()
        {
            try
            {
                return new Employee
                {
                    ShiftList = _context.Shifts.OrderBy(obj => obj.Name).BuildSelectList(),
                    DeptList = _context.Departments.OrderBy(obj => obj.Name).BuildSelectList(),
                    BuildingList = _context.Buildings.OrderBy(obj => obj.Name).BuildSelectList()
                };
            }
            catch
            {
                throw;
            }
        }

        public bool SaveEmployee(Employee employee, string currentUser, bool newEmpl)
        {
            try
            {
                employee.Building = _context.Buildings.FirstOrDefault(obj => obj.BuildingID.Equals(employee.Building.BuildingID));
                employee.Department = _context.Departments.FirstOrDefault(obj => obj.DepartmentID.Equals(employee.Department.DepartmentID));
                employee.Shift = _context.Shifts.FirstOrDefault(obj => obj.ShiftID.Equals(employee.Shift.ShiftID));

                if (newEmpl)
                {
                    employee.CreatedByName = currentUser;
                    employee.CreatedDate = DateTime.Now;

                    _context.Employees.Add(employee);
                }
                else
                {
                    employee.LastModifiedByName = currentUser;
                    employee.LastModifiedDate = DateTime.Now;

                    _context.Entry(employee).State = EntityState.Modified;
                }

                return _context.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                var selectedEmployee = _context.Employees
                    .Include(train => train.TrainingList.OrderByDescending(trainDate => trainDate.TrainingDate))
                    .Include(shift => shift.Shift)
                    .Include(dept => dept.Department)
                    .Include(building => building.Building)
                    .First(emplId => emplId.EmployeeID.Equals(id));

                selectedEmployee.ShiftList = _context.Shifts.OrderBy(obj => obj.Name).BuildSelectList();
                selectedEmployee.DeptList = _context.Departments.OrderBy(obj => obj.Name).BuildSelectList();
                selectedEmployee.BuildingList = _context.Buildings.OrderBy(obj => obj.Name).BuildSelectList();

                return selectedEmployee;
            }
            catch
            {
                throw;
            }
        }

        public bool RetireEmployee(int id)
        {
            try
            {
                var employee = _context.Employees.First(empl => empl.EmployeeID.Equals(id));

                employee.Active = !employee.Active;

                return _context.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
        }
    }
}
