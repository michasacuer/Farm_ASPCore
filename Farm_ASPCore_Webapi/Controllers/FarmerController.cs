using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;
using Farm_ASPCore_Webapi.Models.Bonus;

namespace Farm_ASPCore_Webapi.Controllers
{
    [Route("api/Farmer")]
    [ApiController]
    public class FarmerController : ControllerBase
    {
        private readonly FarmDbContext _context;

        public FarmerController(FarmDbContext context)
        {
            _context = context;
        }

        // GET: api/Farmer
        [HttpGet]
        public IEnumerable<Farmer> GetFarmer()
        {
            return _context.Workers.OfType<Farmer>().ToList();
        }

        // GET: api/Farmer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFarmer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var farmer = await _context.Workers.FindAsync(id);

            if (farmer == null)
            {
                return NotFound();
            }

            return Ok(farmer);
        }

        // PUT: api/Farmer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmer([FromRoute] int id, [FromBody] Farmer farmer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != farmer.Id)
            {
                return BadRequest();
            }

            _context.Entry(farmer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Farmer
        [HttpPost]
        public async Task<IActionResult> PostFarmer([FromBody] Farmer farmer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Workers.Add(farmer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarmer", new { id = farmer.Id }, farmer);
        }

        // DELETE: api/Farmer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var farmer = await _context.Workers.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(farmer);
            await _context.SaveChangesAsync();

            return Ok(farmer);
        }

        private bool FarmerExists(int id)
        {
            return _context.Workers.Any(e => e.Id == id);
        }
    }
}