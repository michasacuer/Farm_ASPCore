using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;

namespace Farm_ASPCore_Webapi.Controllers
{
    [Route("api/Summary")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly FarmDbContext _context;

        public SummaryController(FarmDbContext context)
        {
            _context = context;
        }

        // GET: api/Summary
        [HttpGet]
        public IActionResult GetSummary()
        {
            StrategyPopulate();
            var farm = _context.Farms.Include(w => w.Workers)
                                     .Include(m => m.Machines)
                                     //.Include(c => c.Cultivations)
                                     .Include(s => s.Stables)
                                     .SingleOrDefault();

            var summary = new Summary();
            summary.GetSummary(farm);

            return Ok(new SummaryViewModel
            {
                Budget = summary.Budget,
                AnimalsCost = summary.AnimalsCost,
                CultivationsCost = summary.CultivationsCost,
                MachinesCost = summary.MachinesCost,
                WorkersCost = summary.WorkersCost,
                SummaryCost = summary.SummaryCost,
                Balance = summary.Budget - summary.SummaryCost
            });
        }

        // GET: api/Summary/5
        [HttpGet("{id}")]
        public IActionResult GetSummary([FromRoute] int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var summary =  _context.Summaries.Find(id);

            //if (summary == null)
            //{
            //    return NotFound();
            //}

            //return Ok(summary);
            throw new NotImplementedException();
        }


        private void StrategyPopulate()
        {
            int i = 0;
            foreach (Machine machine in _context.Machines)
            {
                i++;
                if (i % 2 == 0)
                    machine.Strategy = new FarmStrategy();
                else
                    machine.Strategy = new CultivationStrategy();
            }
        }
    }
}