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
    public class TaskEntriesController : ControllerBase
    {
        private readonly TimeframeContext _context;

        public TaskEntriesController(TimeframeContext context)
        {
            _context = context;
        }

        // GET: api/TaskEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskEntry>>> GetTaskEntry()
        {
            return await _context.TaskEntry.ToListAsync();
        }

        // GET: api/TaskEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskEntry>> GetTaskEntry(int id)
        {
            var taskEntry = await _context.TaskEntry.FindAsync(id);

            if (taskEntry == null)
            {
                return NotFound();
            }

            return taskEntry;
        }

        // PUT: api/TaskEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskEntry(int id, TaskEntry taskEntry)
        {
            if (id != taskEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskEntryExists(id))
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

        // POST: api/TaskEntries
        [HttpPost]
        public async Task<ActionResult<TaskEntry>> PostTaskEntry(TaskEntry taskEntry)
        {
            _context.TaskEntry.Add(taskEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskEntry", new { id = taskEntry.Id }, taskEntry);
        }

        // DELETE: api/TaskEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskEntry>> DeleteTaskEntry(int id)
        {
            var taskEntry = await _context.TaskEntry.FindAsync(id);
            if (taskEntry == null)
            {
                return NotFound();
            }

            _context.TaskEntry.Remove(taskEntry);
            await _context.SaveChangesAsync();

            return taskEntry;
        }

        private bool TaskEntryExists(int id)
        {
            return _context.TaskEntry.Any(e => e.Id == id);
        }
    }
}
