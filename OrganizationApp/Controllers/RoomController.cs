using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizationApp.Data;
using OrganizationApp.Models;

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

        [HttpGet]
        public ActionResult<IEnumerable<Room>> AddRoom(int page = 1, int pageSize = 10)
        {
            var rooms = _dbContext.Room.GetPaged(page, pageSize);

            return View(rooms);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(Room room)
        {
            if (!ModelState.IsValid)
            {
                return View(room);
            }

            await _dbContext.Room.AddAsync(room);
            await _dbContext.SaveChangesAsync();
            var rooms = await _dbContext.Room.ToListAsync();

            return RedirectToAction("AddRoom", rooms);
        }
    }
}