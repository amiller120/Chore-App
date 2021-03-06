﻿using Microsoft.AspNetCore.Mvc;
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

        public IViewComponentResult Invoke(AddChoreViewModel chore)
        {
            var listOfPeople = _dataContext.AssignedPerson.ToList();
            var listOfRooms = _dataContext.Room?.ToList();
            var model = new AddChoreViewModel();
            model.ListOfChoices.AddRange(listOfPeople);
            model.ListOfRooms.AddRange(listOfRooms);
            return View(model);
        }

        private Task<List<ChoreItem>> GetChoreItems()
        {
            var chores = _dataContext.ChoreItems.ToListAsync();
            return chores;
        }
    }
}
