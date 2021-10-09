using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRTrainingTracker.Entities.Models
{
    public class State
    {
        public int StateID { get; set; }

        [Required]
        public string StateName { get; set; }

        [Required]
        public string StateCode { get; set; }

        public ICollection<Building> Buildings { get; set; }
    }
}
