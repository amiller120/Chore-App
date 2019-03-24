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
        public ActionResult<IEnumerable<ChoreItem>> Index()
        {
            var chores = _dataContext.choreItems.Include(chore => chore.AssignedTo).ToList();

            return View(chores);
        }

        public ActionResult<IEnumerable<ChoreItem>> AddChore(ChoreItem chore)
        {
            var selectedAssignee = _dataContext.AssignedPerson.Where(x => x.Id == chore.AssignedTo.Id).FirstOrDefault();
            chore.CreatedDate = DateTime.Now;
            chore.AssignedTo = selectedAssignee;
            _dataContext.choreItems.Add(chore);
            _dataContext.SaveChanges();
            var chores = _dataContext.choreItems.Include(x => x.AssignedTo).ToList();

            return RedirectToAction("Index", chores);
        }

        public ActionResult<ChoreItem> Details(int id)
        {
            var chore = _dataContext.choreItems.Include(x => x.AssignedTo).FirstOrDefault(x => x.Id == id);
            return View(chore);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
