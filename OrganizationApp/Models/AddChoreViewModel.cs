using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationApp.Models
{
    public class AddChoreViewModel
    {
        public ChoreItem Chore { get; set; }

        public List<AssignedPerson> ListOfChoices { get; set; }

        public List<Room> ListOfRooms { get; set; }

        public int SelectedId { get; set; }

        public AddChoreViewModel()
        {
            ListOfChoices = new List<AssignedPerson>();
            ListOfRooms = new List<Room>();
        }
    }
}
