using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;
using Microsoft.EntityFrameworkCore.Query;
using Farm_ASPCore_Webapi.Models.Enums;

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


        /// <summary>
        /// Get all leafs from farm
        /// </summary>
        // GET: api/Cultivation
        [HttpGet]
        public IActionResult GetCultivations()
        {
            var leafs = _context.Cultivations.OfType<CultivationLeaf>().Include(c => c.Parent);
            return Ok(GetAllCultivationsFromDb(leafs));
        }


        /// <summary>
        /// Splitting leaf in two parts
        /// </summary>
        // GET: api/Cultivation/Split/1/5
        [HttpGet("Split/{ratio}/{id}")]
        public IActionResult SplitCultivation(double ratio, int id)
        {
            var leaf = _context.Cultivations.Find(id);
            try
            {
                if (leaf.GetType() == typeof(CultivationLeaf))
                {
                    Cultivation leaf1, leaf2, composite;
                    (leaf1, leaf2, composite) = leaf.Split(ratio);

                    composite.Id = leaf.Id;
                    _context.Cultivations.Remove(leaf);
                    _context.Cultivations.Add(leaf1);
                    _context.Cultivations.Add(leaf2);
                    _context.Cultivations.Add(composite);
                }
            }
            catch { return BadRequest(); }

            _context.SaveChanges();
            var leafs = _context.Cultivations.OfType<CultivationLeaf>().Include(c => c.Parent);
            return Ok(GetAllCultivationsFromDb(leafs));
        }

        /// <summary>
        /// Harvest leaf by id
        /// </summary>
        // GET: api/Cultivation/Harvest/5
        [HttpGet("Harvest/{id}")]
        public IActionResult Harvest(int id)
        {
            var leaf = _context.Cultivations.Find(id);
            if (leaf.GetType() == typeof(CultivationLeaf))
                leaf.Harvest();

            else
                return BadRequest();

            return Ok(leaf);
        }

        /// <summary>
        /// Sow leaf by id
        /// </summary>
        // POST: api/Cultivation/Sow/Grain.Kind/5
        [HttpGet("Sow/{grain}/{id}")]
        public IActionResult Sow(int grain, int id)
        {
            var leaf = _context.Cultivations.Find(id);
            if (leaf.GetType() == typeof(CultivationLeaf))
            {
                if (leaf.Grain == Grain.None)
                    leaf.Sow((Grain)grain);
                else
                    return BadRequest();
            }

            else
                return BadRequest();

            return Ok(leaf);
        }

        private List<CultivationViewModel> GetAllCultivationsFromDb(IIncludableQueryable<CultivationLeaf, Cultivation> leafs)
        {
            var result = new List<CultivationViewModel>();

            foreach (CultivationLeaf item in leafs)
            {
                if (!(item.Parent == null))
                    result.Add(new CultivationViewModel { Id = item.Id, CompositeId = item.Parent.Id, Grain = item.Grain.ToString() });

                else
                    result.Add(new CultivationViewModel { Id = item.Id, Grain = item.Grain.ToString() });
            }

            return result;
        }
    }
}