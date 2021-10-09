using HRTrainingTracker.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.Entities.ViewModels
{
    public class EmployeesViewerModel
    {
        public IList<Employee> Employees { get; set; }

        public Employee NewEmployee { get; set; }
    }
}
