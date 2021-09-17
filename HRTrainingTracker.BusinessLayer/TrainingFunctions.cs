using HRTrainingTracker.Entities;
using HRTrainingTracker.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.BusinessLayer
{
    public class TrainingFunctions
    {
        private readonly HRTrainingContext _context;

        public TrainingFunctions(HRTrainingContext context)
        {
            _context = context;
        }

        public IList<Training> BuildTrainingListing()
        {
            try
            {
                return _context.Trainings
                    .Include(employee => employee.Employees)
                    .Include(types => types.TrainingType)
                    .Include(local => local.Locality)
                    .OrderByDescending(item => item.TrainingID)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
