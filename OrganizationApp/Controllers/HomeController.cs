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
            var chores = _dataContext.choreItems.ToList();

            return View(chores);
        }

        public ActionResult<IEnumerable<ChoreItem>> AddChore(ChoreItem chore)
        {
            chore.CreatedDate = DateTime.Now;
            _dataContext.choreItems.Add(chore);
            _dataContext.SaveChanges();
            var chores = _dataContext.choreItems.ToList();

            return View("Index", chores);
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
