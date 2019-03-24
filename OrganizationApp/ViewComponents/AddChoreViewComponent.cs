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
    public class AddChoreViewComponent : ViewComponent
    {
        private DataContext _dataContext;

        public AddChoreViewComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(ChoreItem chore)
        {
                        
            return View(new ChoreItem { Name = "", AssignedTo = "", IsComplete = false });
        }

        private Task<List<ChoreItem>> GetChoreItems()
        {
            var chores = _dataContext.choreItems.Where(x => x.IsComplete==false).ToListAsync();
            return chores;
        }
    }
}
