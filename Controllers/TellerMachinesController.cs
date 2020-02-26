using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Locator.Entities;
using Locator.Models;

namespace Locator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TellerMachinesController : ControllerBase
    {
        private readonly SubDbContext _context;

        public TellerMachinesController(SubDbContext context)
        {
            _context = context;
        }

        // GET: api/TellerMachines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TellerMachine>>> GetTellerMachines()
        {
            return await _context.TellerMachines.ToListAsync();
        }

        // GET: api/TellerMachines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TellerMachine>> GetTellerMachine(string id)
        {
            var tellerMachine = await _context.TellerMachines.FindAsync(id);

            if (tellerMachine == null)
            {
                return NotFound();
            }

            return tellerMachine;
        }

        // PUT: api/TellerMachines/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTellerMachine(string id, TellerMachine tellerMachine)
        {
            if (id != tellerMachine.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(tellerMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TellerMachineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TellerMachines
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TellerMachine>> PostTellerMachine(TellerMachine tellerMachine)
        {
            _context.TellerMachines.Add(tellerMachine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TellerMachineExists(tellerMachine.LocationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTellerMachine", new { id = tellerMachine.LocationId }, tellerMachine);
        }

        // DELETE: api/TellerMachines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TellerMachine>> DeleteTellerMachine(string id)
        {
            var tellerMachine = await _context.TellerMachines.FindAsync(id);
            if (tellerMachine == null)
            {
                return NotFound();
            }

            _context.TellerMachines.Remove(tellerMachine);
            await _context.SaveChangesAsync();

            return tellerMachine;
        }

        private bool TellerMachineExists(string id)
        {
            return _context.TellerMachines.Any(e => e.LocationId == id);
        }
    }
}
