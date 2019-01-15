using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Farm_ASPCore_Webapi.Models;
using Farm_ASPCore_Webapi.Models.Enums;
using Microsoft.EntityFrameworkCore;

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
            return Farm.GetInstance(_context).Workers;
        }

        // POST: api/Worker
        [HttpPost]
        public IActionResult AddWorker(Worker worker)
        {
            var workers = Farm.GetInstance(_context).Workers;

            if (worker.Kind == Job.Driver)
                workers.Add((Driver)worker);

            if (worker.Kind == Job.Farmer)
                workers.Add((Farmer)worker);

            _context.Workers.Add(worker);
            _context.SaveChanges();

            return Ok();
        }

        // POST: api/Worker/5/job/0
        [HttpPost("{id}/Job/{job}")]
        public IActionResult ChangeJob(int id, int job)
        {
            var worker = _context.Workers.Find(id);
            worker.Kind = (Job)job;

            if (worker.Kind == Job.Driver)
                worker = (Driver)worker;

            if (worker.Kind == Job.Farmer)
                worker = (Farmer)worker;

            _context.Entry(worker).State = EntityState.Modified;

            _context.SaveChanges();
            return Ok(worker);
        }


        // GET: api/Worker/5
        [HttpGet("{id}")]
        public IActionResult GetWorker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var worker = Farm.GetInstance(_context).Workers.Find(w => w.Id == id);

            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        // DELETE: api/Worker/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWorker([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var worker = Farm.GetInstance(_context).Workers.Find(w => w.Id == id);
            if (worker == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(worker);
            _context.SaveChanges();

            return Ok(worker);
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.Id == id);
        }
    }
}