using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizationApp.Data;
using OrganizationApp.Models;

namespace OrganizationApp.Controllers
{
    public class HomeController : Controller
    {
        private DataContext _dataContext;

        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public ActionResult<IEnumerable<ChoreItem>> Index(int page=1, int pageSize=10)
        {
            var chores = _dataContext.ChoreItems.Include(chore => chore.AssignedTo).Include(chore => chore.Room).GetPaged(page, pageSize);

            return View(chores);
        }

        [HttpGet]
        public ActionResult<IEnumerable<AssignedPerson>> AddPerson(int page=1, int pageSize=10)
        {
            var people = _dataContext.AssignedPerson.GetPaged(page, pageSize);

            return View(people);
        } 

        [HttpPost]
        public ActionResult<AssignedPerson> AddPerson(AssignedPerson person)
        {
            if (ModelState.IsValid)
            {
                _dataContext.AssignedPerson.Add(person);
                _dataContext.SaveChanges();
                var people = _dataContext.AssignedPerson.ToList();

                return RedirectToAction("AddPerson", people);
            }

            return BadRequest();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> AddRoom(int page=1, int pageSize = 10)
        {
            var rooms = _dataContext.Room.GetPaged(page, pageSize);

            return View(rooms);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                await _dataContext.Room.AddAsync(room);
                await _dataContext.SaveChangesAsync();
                var rooms = await _dataContext.Room.ToListAsync();

                return RedirectToAction("AddRoom", rooms);
            }

            return BadRequest();            
        }

        public ActionResult<IEnumerable<ChoreItem>> AddChore(ChoreItem chore)
        {
            var selectedAssignee = _dataContext.AssignedPerson.Where(x => x.Id == chore.AssignedTo.Id).FirstOrDefault();
            var selectedRoom = _dataContext.Room.FirstOrDefault(x => x.Id == chore.Room.Id);
            chore.CreatedDate = DateTime.Now;
            chore.AssignedTo = selectedAssignee;
            chore.Room = selectedRoom;
            chore.StartDate = DateTime.Now;
            chore.DueDate = DateTime.Now.AddDays(10);
            _dataContext.ChoreItems.Add(chore);
            _dataContext.SaveChanges();
            var chores = _dataContext.ChoreItems.Include(x => x.AssignedTo).Include(x => x.Room).ToList();

            return RedirectToAction("Index", chores);
        }

        public ActionResult<ChoreItem> Details(int id)
        {
            var chore = _dataContext.ChoreItems.Include(x => x.AssignedTo).Include(x => x.Room).FirstOrDefault(x => x.Id == id);
            return View(chore);
        }

        public ActionResult<IEnumerable<ChoreItem>> FinishChore(int id)
        {
            var chore = _dataContext.ChoreItems.Include(x => x.AssignedTo).SingleOrDefault(x => x.Id == id);
            chore.StartDate = DateTime.Now;
            chore.DueDate = DateTime.Now.AddDays(10);
            _dataContext.ChoreItems.Update(chore);
            _dataContext.SaveChanges();
            var chores = _dataContext.ChoreItems.Include(x => x.AssignedTo).ToList();

            return RedirectToAction("Index", chores);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
