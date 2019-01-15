using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Farm_ASPCore_Webapi.Models;
using Farm_ASPCore_Webapi.Models.Enums;

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

        // GET: api/Worker/5/job/0
        [HttpPost("{id}/Job/{job}")]
        public IActionResult ChangeJob(int id, int job)
        {
            var worker = _context.Workers.Find(id);
            worker.Kind = (Job)job;

            if (worker.Kind == Job.Driver)
                worker = (Driver)worker;

            if (worker.Kind == Job.Farmer)
                worker = (Farmer)worker;

            _context.SaveChanges();
            return Ok(worker);
        }


        // GET: api/Worker/5
        [HttpGet("{id}")]
        public IActionResult GetWorker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var worker = _context.Workers.Find(id);

            if (worker == null)
                return NotFound();

            return Ok(worker);
        }

        // POST: api/Worker
        [HttpPost]
        public IActionResult PostWorker(Worker worker)
        {
            var workers = _context.Workers;

            try
            {
                if(worker.Kind == Job.Driver)
                    worker = (Driver)worker;

                if (worker.Kind == Job.Farmer)
                    worker = (Farmer)worker;

                workers.Add(worker);
            }
            catch { BadRequest(); }

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