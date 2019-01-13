using Farm_ASPCore_Webapi.Helpers;
using Farm_ASPCore_Webapi.Models;
using Farm_ASPCore_Webapi.Models.Bonus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Farm_ASPCore_Webapi.Controllers
{
    [Route("api/Bonus")]
    [ApiController]
    public class BonusController : ControllerBase
    {
        private readonly FarmDbContext _context;

        public BonusController(FarmDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Attach Bonus on worker's salary
        /// </summary>
        // POST: api/Bonus/Amount/5
        [HttpPost("{kind}/{id}")]
        public IActionResult PutBonus(int id, string kind)
        {
            var worker = _context.Workers.Find(id);

            try
            {
                Bonus decorated;
                switch (kind.ToLower())
                {
                    case Routes.AmountBonus:
                        decorated = new AmountBonus(worker);
                        worker.Salary = decorated.Salary;
                        break;

                    case Routes.PercentBonus:
                        decorated = new PercentBonus(worker);
                        worker.Salary = decorated.Salary;
                        break;

                    case Routes.DiscretionaryBonus:
                        decorated = new PercentBonus(worker);
                        worker.Salary = decorated.Salary;
                        break;
                }
            }
            catch { return BadRequest(); }

            _context.Entry(worker).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(worker);
        }

        /// <summary>
        /// Reset bonuses for all workers
        /// </summary>
        //POST api/Bonus/Reset
        [HttpPost("Reset")]
        public IActionResult ResetAllBonuses()
        {
            var workers = _context.Workers;

            try
            {
                foreach(Worker worker in workers)
                {
                    worker.Salary = worker.BaseSalary;
                    _context.Entry(worker).State = EntityState.Modified;
                }
            }
            catch { return BadRequest(); }

            _context.SaveChanges();

            return Ok(workers);
        }


        /// <summary>
        /// Reset Bonus for Worker where id = worker.Id
        /// </summary>
        // POST: api/Reset/5
        [HttpPost("Reset/{id}")]
        public IActionResult ResetBonus(int id)
        {
            var worker = _context.Workers.Find(id);

            try
            {
                worker.Salary = worker.BaseSalary;
                _context.Entry(worker).State = EntityState.Modified;
            }
            catch { return BadRequest(); }

            _context.SaveChanges();

            return Ok(worker);
        }
    }
}
