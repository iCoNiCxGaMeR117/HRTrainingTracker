using HRTrainingTracker.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.Entities.ViewModels
{
    public class TrainingsViewerModel
    {
        public IList<Training> Trainings { get; set; }

        public Training NewTraining { get; set; }
    }
}
