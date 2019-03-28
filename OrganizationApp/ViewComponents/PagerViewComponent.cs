using Microsoft.AspNetCore.Mvc;
using OrganizationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationApp.ViewComponents
{
    public class PagerViewComponent : ViewComponent
    {
        // https://www.codingame.com/playgrounds/5368/building-pager-component-for-asp-net-core
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
