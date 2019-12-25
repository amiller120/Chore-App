using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizationApp.Data;
using OrganizationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OrganizationApp.ViewComponents
{
    public class AddAssignedPersonViewComponent : ViewComponent
    {
        private DataContext _dataContext;

        public AddAssignedPersonViewComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(AddAssignedPersonViewModel chore)
        {
            var model = new AddAssignedPersonViewModel();
            return View(model);
        }

        // private Task<List<ChoreItem>> GetChoreItems()
        // {
        //     var chores = _dataContext.ChoreItems.Where(x => x.IsComplete==false).ToListAsync();
        //     return chores;
        // }
    }
}
