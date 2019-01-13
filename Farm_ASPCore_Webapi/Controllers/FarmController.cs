using System.Linq;
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

        /// <summary>
        /// Get info of farm
        /// </summary>
        // GET: api/Farm
        [HttpGet]
        public IActionResult GetFarms() => Ok(_context.Farms.SingleOrDefault());

        /// <summary>
        /// Get Farm with lists from database
        /// </summary>
        //Get: api//Farm/All
        [HttpGet("All")]
        public IActionResult GetFarmsAll() => Ok(_context.Farms.Include(w => w.Workers)
                                                               .Include(m => m.Machines)
                                                               //.Include(c => c.Cultivations)
                                                               .Include(s => s.Stables)
                                                               .SingleOrDefault());
    }
}