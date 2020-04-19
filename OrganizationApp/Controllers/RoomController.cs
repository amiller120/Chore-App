using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrganizationApp.Data;

namespace OrganizationApp.Controllers
{
    public class RoomController : Controller
    {
        private DataContext _dbContext;
        public RoomController(DataContext dataContext)
        {
            _dbContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rooms(int id)
        {
            var room = _dbContext.Room.FirstOrDefault(r => r.Id == id);
            var choresForRoom = _dbContext.ChoreItems.Where(x => x.RoomId == room.Id);
            room.ChoreItems = choresForRoom.ToList();
            var model = room.ToViewModel();

            return View(model);
        }
    }
}