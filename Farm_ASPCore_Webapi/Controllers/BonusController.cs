using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farm_ASPCore_Webapi.Models;
using Farm_ASPCore_Webapi.Models.Bonus;
using Microsoft.AspNetCore.Http;
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

        // PUT: api/Bonus/Amount/5
        [HttpPut("{kind}/{id}")]
        public IActionResult PutBonus(int id, string kind)
        {
            var worker = _context.Workers.Find(id);

            try
            {
                Bonus decorated;
                switch (kind.ToLower())
                {
                    case "amount":
                        decorated = new AmountBonus(worker);
                        worker.Salary = decorated.Salary;
                        break;

                    case "percent":
                        decorated = new PercentBonus(worker);
                        worker.Salary = decorated.Salary;
                        break;

                    case "discretionary":
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

        //PUT api/Bonus/Reset
        [HttpPut("Reset")]
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

        [HttpPut("Reset/{id}")]
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
