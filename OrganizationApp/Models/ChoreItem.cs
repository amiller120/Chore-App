using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationApp.Models
{
    public class ChoreItem
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public DateTime StartDate {get; set;}

        public DateTime DueDate {get; set;}

        public bool IsComplete { get; set; }
        
        public AssignedPerson AssignedTo { get; set; }
    }
}
