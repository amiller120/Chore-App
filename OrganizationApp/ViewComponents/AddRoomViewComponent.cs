using Microsoft.AspNetCore.Mvc;
using OrganizationApp.Data;
using OrganizationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationApp.ViewComponents
{
    public class AddRoomViewComponent : ViewComponent
    {
        private DataContext _dataContext;

        public AddRoomViewComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IViewComponentResult Invoke(AddRoomViewModel chore)
        {
            var model = new AddRoomViewModel();
            return View(model);
        }
    }
}
