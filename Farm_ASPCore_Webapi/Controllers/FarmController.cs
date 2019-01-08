using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;

namespace Farm_ASPCore_Webapi.Controllers
{
    [Route("api/Farm")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly FarmDbContext _context;

        public FarmController(FarmDbContext context)
        {
            _context = context;
        }

        // GET: api/Farm
        [HttpGet]
        public IActionResult GetFarms() => Ok(_context.Farms.SingleOrDefault());

        //Get: api//Farm/All
        [HttpGet("All")]
        public IActionResult GetFarmsAll() => Ok(_context.Farms.Include(w => w.Workers)
                                                               .Include(m => m.Machines)
                                                               //.Include(c => c.Cultivations)
                                                               .Include(s => s.Stables)
                                                               .SingleOrDefault());

        // PUT: api/Farm/5
        [HttpPut]
        public async Task<IActionResult> PutFarm([FromBody] Farm farm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!await _context.Farms.AnyAsync(f => f.Id == farm.Id))
            {
                return BadRequest(ModelState);
            }

            _context.Entry(farm).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}