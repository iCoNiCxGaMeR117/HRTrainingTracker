using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.Entities.Models
{
    public class TrainingTypes
    {
        public int TrainingTypesID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime CreatedDate { get; set; }

        public string CreatedByName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? LastModifiedDate { get; set; }

        public string LastModifiedByName { get; set; }

        public ICollection<Training> Trainings { get; set; }
    }
}