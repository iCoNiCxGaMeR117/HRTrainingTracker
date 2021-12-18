using HRTrainingTracker.Entities;
using HRTrainingTracker.Entities.Models;
using HRTrainingTracker.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.BusinessLayer
{
    public class HomeFunctions
    {
        private readonly HRTrainingContext _context;

        public HomeFunctions(HRTrainingContext context)
        {
            _context = context;
        }

        public HomeViewerModel GetExpiringTrainings()
        {
            var today = DateTime.Today;
            var expThresh = today.AddMonths(3);
            var yellowThresh = today.AddMonths(1);
            var redThresh = today.AddDays(7);

            var expiringTrainings = _context.Trainings
                .Where(exp => (exp.TrainingExpiration != null && exp.TrainingExpiration.Value <= expThresh) && !exp.Expired)
                .ToList();

            var green = expiringTrainings
                .Where(exp => exp.TrainingExpiration.Value <= expThresh && exp.TrainingExpiration.Value > yellowThresh)
                .OrderBy(date => date.TrainingExpiration.Value);

            var yellow = expiringTrainings
                .Where(exp => exp.TrainingExpiration.Value <= yellowThresh && exp.TrainingExpiration.Value > redThresh)
                .OrderBy(date => date.TrainingExpiration.Value);

            var red = expiringTrainings
                .Where(exp => exp.TrainingExpiration.Value <= redThresh && exp.TrainingExpiration.Value >= today)
                .OrderBy(date => date.TrainingExpiration.Value);

            var expired = expiringTrainings
                .Where(exp => exp.TrainingExpiration.Value < today)
                .OrderBy(date => date.TrainingExpiration.Value);

            return new HomeViewerModel
            {
                GreenTraining = green,
                YellowTraining = yellow,
                RedTraining = red,
                ExpiredTrainings = expired
            };
        }
    }
}
