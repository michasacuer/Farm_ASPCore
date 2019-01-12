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
            var farm = _context.Farms.Include(w => w.Workers)
                                     .Include(m => m.Machines)
                                     //.Include(c => c.Cultivations)
                                     .Include(s => s.Stables)
                                     .SingleOrDefault();

            var summary = new Summary();
            summary.GetSummary(farm);
            _context.Summaries.Add(summary);
            _context.SaveChanges();
            return Ok(summary);
        }

        // GET: api/Summary/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSummary([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var summary = await _context.Summaries.FindAsync(id);

            if (summary == null)
            {
                return NotFound();
            }

            return Ok(summary);
        }

       

        private bool SummaryExists(int id)
        {
            return _context.Summaries.Any(e => e.Id == id);
        }
    }
}