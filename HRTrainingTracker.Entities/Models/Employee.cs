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
    public class Employee
    {
        #region Table Items
        public int EmployeeID { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public Shift Shift { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime HireDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime? TransferDate { get; set; }

        [Required]
        public Building Building { get; set; }

        [Required]
        public Department Department { get; set; }

        [Required]
        public bool Active { get; set; } = true;

        [Required]
        public bool Manager { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedByName { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string LastModifiedByName { get; set; }

        public ICollection<Training> TrainingList { get; set; }
        #endregion

        #region Custom Additions
        [NotMapped]
        public IList<SelectListItem> ShiftList { get; set; }

        [NotMapped]
        public IList<SelectListItem> BuildingList { get; set; }

        [NotMapped]
        public IList<SelectListItem> DeptList { get; set; }
        #endregion
    }
}
