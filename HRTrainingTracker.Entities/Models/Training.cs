using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.Entities.Models
{
    public class Training
    {
        public int TrainingID { get; set; }

        [Required]
        public string TrainingName { get; set; }

        public string TrainingDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime TrainingDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? TrainingExpiration { get; set; }

        [Required]
        public string TrainerName { get; set; }

        [Required]
        public TrainingTypes TrainingType { get; set; }

        [Required]
        public Local Locality { get; set; }

        [Required]
        public bool Expired { get; set; } = false;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime CreatedDate { get; set; }

        public string CreatedByName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? LastModifiedDate { get; set; }

        public string LastModifiedByName { get; set; }

        public ICollection<Employee> Employees { get; set; }

        [NotMapped]
        public IList<SelectListItem> TrainingTypesList { get; set; }

        [NotMapped]
        public IList<SelectListItem> LocalitiesList { get; set; }
    }
}
