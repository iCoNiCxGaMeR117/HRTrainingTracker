using HRTrainingTracker.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.Entities.ViewModels
{
    public class HomeViewerModel
    {
        //3 months out
        public IOrderedEnumerable<Training> GreenTraining { get; set; }

        //1 month out
        public IOrderedEnumerable<Training> YellowTraining { get; set; }

        //1 week out
        public IOrderedEnumerable<Training> RedTraining { get; set; }

        //Expired
        public IOrderedEnumerable<Training> ExpiredTrainings { get; set; }
    }
}
