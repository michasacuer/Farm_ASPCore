using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Farm_ASPCore_Webapi.Models;

namespace Farm_ASPCore_Webapi.Controllers
{
    [Route("api/Worker")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly FarmDbContext _context;

        public WorkerController(FarmDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all workers
        /// </summary>
        // GET: api/Worker
        [HttpGet]
        public IEnumerable<Worker> GetWorkers()
        {
            return _context.Workers;
        }

        // GET: api/Worker/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var worker = await _context.Workers.FindAsync(id);

            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        // DELETE: api/Worker/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();

            return Ok(worker);
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.Id == id);
        }
    }
}