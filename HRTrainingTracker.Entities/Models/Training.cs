using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.Entities.Models
{
    public class Training
    {
        public int TrainingID { get; set; }

        public string TrainingName { get; set; }

        public IList<Employee> WithTraining { get; set; }
    }
}
