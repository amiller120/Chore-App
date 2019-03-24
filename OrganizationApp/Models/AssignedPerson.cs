using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationApp.Models
{
    public class AssignedPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ChoreItem> Chores { get; set; }

        
    }
}
