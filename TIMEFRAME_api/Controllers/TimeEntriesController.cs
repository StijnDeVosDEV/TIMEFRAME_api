using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TIMEFRAME_api.Data;
using TIMEFRAME_api.MODELS;

namespace TIMEFRAME_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntriesController : ControllerBase
    {
        private readonly TimeframeContext _context;

        public TimeEntriesController(TimeframeContext context)
        {
            _context = context;
        }

        // GET: api/TimeEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeEntry>>> GetTimeEntry()
        {
            return await _context.TimeEntry.ToListAsync();
        }

        // GET: api/TimeEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeEntry>> GetTimeEntry(int id)
        {
            var timeEntry = await _context.TimeEntry.FindAsync(id);

            if (timeEntry == null)
            {
                return NotFound();
            }

            return timeEntry;
        }

        // PUT: api/TimeEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeEntry(int id, TimeEntry timeEntry)
        {
            if (id != timeEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(timeEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeEntryExists(id))
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

        // POST: api/TimeEntries
        [HttpPost]
        public async Task<ActionResult<TimeEntry>> PostTimeEntry(TimeEntry timeEntry)
        {
            _context.TimeEntry.Add(timeEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimeEntry", new { id = timeEntry.Id }, timeEntry);
        }

        // DELETE: api/TimeEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeEntry>> DeleteTimeEntry(int id)
        {
            var timeEntry = await _context.TimeEntry.FindAsync(id);
            if (timeEntry == null)
            {
                return NotFound();
            }

            _context.TimeEntry.Remove(timeEntry);
            await _context.SaveChangesAsync();

            return timeEntry;
        }

        private bool TimeEntryExists(int id)
        {
            return _context.TimeEntry.Any(e => e.Id == id);
        }
    }
}
