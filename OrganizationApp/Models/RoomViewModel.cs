using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationApp.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ChoreItem> Chores { get; set; }

        public RoomViewModel()
        {
            Chores = new List<ChoreItem>();
        }

        public Room ToModel()
        {
            Room room = new Room
            {
                Id = Id,
                ChoreItems = Chores,
                Name = Name
            };

            return room;
        }
    }
}
