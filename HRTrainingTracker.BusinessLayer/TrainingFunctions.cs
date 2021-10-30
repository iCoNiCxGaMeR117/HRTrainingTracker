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
    public class TrainingFunctions
    {
        private readonly HRTrainingContext _context;

        public TrainingFunctions(HRTrainingContext context)
        {
            _context = context;
        }

        public TrainingsViewerModel InitializeTrainingsViewer()
        {
            return new TrainingsViewerModel
            {
                Trainings = BuildTrainingListing(),
                NewTraining = BuildNewTraining()
            };
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

        public Training BuildNewTraining()
        {
            return new Training
            {
                TrainingTypesList = _context.TrainingTypes.OrderBy(name => name.TrainingTypeName).BuildSelectList(),
                LocalitiesList = _context.Localities.OrderBy(name => name.Name).BuildSelectList()
            };
        }

        public bool SaveTraining(Training training, string currentUser, bool newTraining)
        {
            try
            {
                training.TrainingType = _context.TrainingTypes.FirstOrDefault(obj => obj.TrainingTypesID.Equals(training.TrainingType.TrainingTypesID));
                training.Locality = _context.Localities.FirstOrDefault(obj => obj.LocalID.Equals(training.Locality.LocalID));

                if (newTraining)
                {
                    training.CreatedByName = currentUser;
                    training.CreatedDate = DateTime.Now;

                    _context.Trainings.Add(training);
                }
                else
                {
                    training.LastModifiedByName = currentUser;
                    training.LastModifiedDate = DateTime.Now;

                    _context.Entry(training).State = EntityState.Modified;
                }

                return _context.SaveChanges() > 0;
            }
            catch
            {
                throw;
            }
        }

        public Training GetTrainingById(int trainingID)
        {
            var training = _context.Trainings
                .Include(empl => empl.Employees)
                .Include(type => type.TrainingType)
                .Include(local => local.Locality)
                .Single(id => id.TrainingID.Equals(trainingID));

            training.TrainingTypesList = _context.TrainingTypes
                .OrderBy(name => name.TrainingTypeName)
                .BuildSelectList();

            training.LocalitiesList = _context.Localities
                .OrderBy(name => name.Name)
                .BuildSelectList();

            training.AttachEmployeeList = _context.Employees
                .Include(dept => dept.Department)
                .Where(empl => empl.Active && !training.Employees.Contains(empl))
                .OrderBy(nm => nm.LastName)
                .ToList();

            return training;
        }
    }
}
