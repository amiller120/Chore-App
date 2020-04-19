using System;
using System.ComponentModel.DataAnnotations;

namespace OrganizationApp.Models
{
    public class ChoreItem
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime StartDate {get; set;}

        public DateTime DueDate {get; set;}

        [Required(ErrorMessage ="You must have a person assigned to a chore.")]
        public AssignedPerson AssignedTo { get; set; }

        public int RoomId { get; set; }

        [Required]
        public Room Room { get; set; }
    }
}
