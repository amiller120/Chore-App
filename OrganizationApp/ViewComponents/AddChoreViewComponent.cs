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

        public async Task<IViewComponentResult> InvokeAsync(AddChoreViewModel chore)
        {
            var listOfPeople = _dataContext.AssignedPerson.ToList();            
            var model = new AddChoreViewModel();
            model.ListOfChoices.AddRange(listOfPeople);
            return View(model);
        }

        private Task<List<ChoreItem>> GetChoreItems()
        {
            var chores = _dataContext.ChoreItems.Where(x => x.IsComplete==false).ToListAsync();
            return chores;
        }
    }
}
