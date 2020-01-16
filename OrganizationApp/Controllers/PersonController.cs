using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizationApp.Data;
using OrganizationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private DataContext _dataContext;

        public PersonController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Get: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignedPerson>>> GetAssignedPeople()
        {
            var people = await _dataContext.AssignedPerson.Include(x => x.Chores).ToListAsync();
            return people;
        }

        // Get : api/Person/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignedPerson>> GetPerson(int id)
        {
            var person = await _dataContext.AssignedPerson.SingleOrDefaultAsync(x => x.Id == id);
            // Alternatively the below code will work as well
            // var person = Task.Run(() => _dataContext.AssignedPerson.SingleOrDefault(x => x.Id == id);
            // var result = await person;
            // return result;
            return person;
        }
    }
}
