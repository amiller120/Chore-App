using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationApp.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<ChoreItem> ChoreItems { get; set; }

        public RoomViewModel ToViewModel()
        {
            RoomViewModel model = new RoomViewModel
            {
                Chores = ChoreItems,
                Id = Id,
                Name = Name
            };

            return model;
        }
    }

    
}
