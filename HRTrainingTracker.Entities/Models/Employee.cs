using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.Entities.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Shift Shift { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public DateTime? TransferDate { get; set; }

        [Required]
        public Building Building { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public bool Manager { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime CreatedDate { get; set; }

        public string CreatedByName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? LastModifiedDate { get; set; }

        public string LastModifiedByName { get; set; }

        public ICollection<Training> TrainingList { get; set; }
    }
}
