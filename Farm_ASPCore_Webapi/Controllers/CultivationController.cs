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
    [Route("api/Cultivation")]
    [ApiController]
    public class CultivationController : ControllerBase
    {
        private readonly FarmDbContext _context;

        public CultivationController(FarmDbContext context)
        {
            _context = context;
        }

        // GET: api/Cultivation
        [HttpGet]
        public IActionResult GetCultivations()
        {
            var leafs = _context.Cultivations.OfType<CultivationLeaf>().Include(c => c.Parent);
            var response = new List<CultivationViewModel>();
            foreach(CultivationLeaf item in leafs)
            {
                response.Add(new CultivationViewModel { Id = item.Id, CompositeId = item.Parent.Id, Grain = item.Grain.ToString() });
            }

            return Ok(response);
        }

        // GET: api/Cultivation/Split/ratio idk co to ma byc xD /5
        [HttpGet("Split/{ratio}/{id}")]
        public IActionResult GetCultivation(int ratio, int id)
        {
            var leaf = _context.Cultivations.Find(id);
            try
            {
                leaf.Split(ratio);
            }

            catch
            {
                return BadRequest();
            }

            return Ok();

        }

        // PUT: api/Cultivation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCultivation([FromRoute] int id, [FromBody] Cultivation cultivation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cultivation.Id)
            {
                return BadRequest();
            }

            _context.Entry(cultivation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CultivationExists(id))
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

        // POST: api/Cultivation
        [HttpPost]
        public async Task<IActionResult> PostCultivation([FromBody] Cultivation cultivation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cultivations.Add(cultivation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCultivation", new { id = cultivation.Id }, cultivation);
        }

        // DELETE: api/Cultivation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCultivation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cultivation = await _context.Cultivations.FindAsync(id);
            if (cultivation == null)
            {
                return NotFound();
            }

            _context.Cultivations.Remove(cultivation);
            await _context.SaveChangesAsync();

            return Ok(cultivation);
        }

        private bool CultivationExists(int id)
        {
            return _context.Cultivations.Any(e => e.Id == id);
        }
    }
}