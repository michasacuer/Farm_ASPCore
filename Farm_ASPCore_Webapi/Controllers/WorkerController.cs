using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Farm_ASPCore_Webapi.Models;
using Farm_ASPCore_Webapi.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Helpers;

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

        // POST: api/Worker/0
        [HttpPost("0")]
        public IActionResult AddWorker(Driver worker)
        {
            try
            {
                worker.CountBaseSalary();
                _context.Workers.Add(worker);
                _context.SaveChanges();

                Farm.GetInstance(_context).Workers.Add(_context.Workers.Find(worker.Id));
                return Ok(worker);
            }
            catch { return BadRequest(new BadRequestViewModel { Message = "Błąd przy zapisie kierowcy!" }); };
        }

        //Post: api/Worker/1
        [HttpPost("1")]
        public IActionResult AddWorker(Farmer worker)
        {
            try
            {
                worker.CountBaseSalary();
                _context.Workers.Add(worker);
                _context.SaveChanges();

                Farm.GetInstance(_context).Workers.Add(_context.Workers.Find(worker.Id));
                return Ok(worker);
            }
            catch { return BadRequest(new BadRequestViewModel { Message = "Błąd przy zapisie farmera!" }); };
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
        public IActionResult DeleteWorker(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var worker = _context.Workers.SingleOrDefault(w => w.Id == id);
            _context.Workers.Remove(worker);

            Farm.GetInstance(_context).Workers.Remove(worker);

            if (worker == null)
            {
                return NotFound();
            }

            _context.SaveChanges();

            return Ok(worker);
        }

        private bool WorkerExists(int id)
        {
            return _context.Workers.Any(e => e.Id == id);
        }
    }
}