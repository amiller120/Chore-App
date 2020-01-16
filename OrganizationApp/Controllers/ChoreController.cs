using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganizationApp.Data;
using OrganizationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrganizationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoreController : ControllerBase
    {
        private DataContext _dataContext;

        public ChoreController(DataContext dataContext)
        {
            _dataContext = dataContext;                                                
        }

        // Get: api/Chore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChoreItem>>> GetChoreItems()
        {
            var chores = await _dataContext.ChoreItems.Include(chore => chore.AssignedTo).OrderBy(chore => chore.Id).ToListAsync();
            return chores;
        }

        // GET: api/Chore/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ChoreItem>> GetChoreItem(int id)
        {
            var choreItem = await _dataContext.ChoreItems.Include(chore => chore.AssignedTo).Where(x => x.Id == id).SingleOrDefaultAsync();

            if (choreItem == null)
            {
                return NotFound();
            }

            return choreItem;
        }

        // POST: api/Chore
        [HttpPost]
        public async Task<ActionResult<ChoreItem>> PostChoreItem(ChoreItem chore)
        {
            if (ModelState.IsValid)
            {
                var assigned = _dataContext.AssignedPerson.SingleOrDefault(x => x.Id == chore.AssignedTo.Id);
                chore.AssignedTo = assigned;
                _dataContext.ChoreItems.Add(chore);
                await _dataContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetChoreItem), new { id = chore.Id }, chore);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        // PUT: api/chore/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChoreItem(int id, ChoreItem chore)
        {
            if (id != chore.Id)
            {
                return BadRequest();
            }

            _dataContext.Entry(chore).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }



    }
}
