using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;

namespace Farm_ASPCore_Webapi.Controllers
{
    [Route("api/Driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly FarmDbContext _context;

        public DriverController(FarmDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get workers that work as Drivers
        /// </summary>
        // GET: api/Driver
        [HttpGet]
        public IEnumerable<Driver> GetDriver()
        {
            return Farm.GetInstance(_context).Workers.OfType<Driver>().ToList(); ;
        }

        // GET: api/Driver/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriver([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driver = await _context.Workers.SingleOrDefaultAsync(i => i.Id == id);

            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        // PUT: api/Driver/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver([FromRoute] int id, [FromBody] Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driver.Id)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        // POST: api/Driver
        [HttpPost]
        public async Task<IActionResult> PostDriver([FromBody] Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Workers.Add(driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriver", new { id = driver.Id }, driver);
        }



        // DELETE: api/Driver/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var driver = await _context.Workers.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(driver);
            await _context.SaveChangesAsync();

            return Ok(driver);
        }

        private bool DriverExists(int id)
        {
            return _context.Workers.Any(e => e.Id == id);
        }
    }
}