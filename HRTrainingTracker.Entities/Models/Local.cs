using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.Entities.Models
{
    public class Local
    {
        public int LocalID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Training> Trainings { get; set; }
    }
}
