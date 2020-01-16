using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationApp.Models
{
    public class ChoreItem
    {
        [Required(ErrorMessage ="The Id is required when adding a chore.")]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime StartDate {get; set;}

        public DateTime DueDate {get; set;}

        [Required(ErrorMessage ="You must have an person assigned to a chore.")]
        public AssignedPerson AssignedTo { get; set; }
    }
}
