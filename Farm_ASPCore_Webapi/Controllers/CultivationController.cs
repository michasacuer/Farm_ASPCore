using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;
using Microsoft.EntityFrameworkCore.Query;
using Farm_ASPCore_Webapi.Models.Enums;
using Farm_ASPCore_Webapi.Helpers;

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
        public IActionResult GetCultivations() => Ok(GetCultivationsFromDb(Farm.GetInstance(_context).Cultivations.OfType<CultivationLeaf>()));

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
                    var (leaf1, leaf2, composite) = leaf.Split(ratio);

                    composite.Id = leaf.Id;
                    _context.Cultivations.Remove(leaf);
                    _context.Cultivations.Add(leaf1);
                    _context.Cultivations.Add(leaf2);
                    _context.Cultivations.Add(composite);
                }
            }
            catch { return BadRequest(); }

            _context.SaveChanges();
            var farm = Farm.GetInstance(_context);
            farm.Cultivations = _context.Cultivations.ToList();
            return Ok(GetCultivationsFromDb(farm.Cultivations.OfType<CultivationLeaf>()));
        }

        /// <summary>
        /// Harvest leafs
        /// </summary>
        // GET: api/Cultivation/Harvest
        [HttpGet("Harvest")]
        public IActionResult Harvest()
        {
            var leafs = Farm.GetInstance(_context).Cultivations;

            foreach (Cultivation leaf in leafs)
            {
                leaf.Harvest();

                _context.Entry(leaf).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return Ok(GetCultivationsFromDb(leafs));
        }

        /// <summary>
        /// Sow leaf by id
        /// </summary>
        // GET: api/Cultivation/Sow/Grain.Kind/5
        [HttpGet("Sow/{grain}/{id}")]
        public IActionResult Sow(int grain, int id)
        {
            var leaf = Farm.GetInstance(_context).Cultivations.Find(c => c.Id == id);

            try   { leaf.Sow((Grain)grain); }
            catch { return BadRequest(new BadRequestViewModel { Message = "Leaf is sowed" }); }

            if (leaf.GetType() == typeof(CultivationLeaf))
            {
                _context.Entry(leaf).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(new CultivationViewModel { Id = leaf.Id, Grain = leaf.Grain.ToString()});
            }
            else
            {
                foreach (Cultivation item in leaf.GetCompositeLeafs())
                {
                    _context.Entry(item).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return Ok(GetCultivationsFromDb(leaf.GetCompositeLeafs()));
            }
        }

        //POST: api/Cultivation
        [HttpPost]
        public IActionResult CreateLeaf(CultivationLeaf cultivation)
        {
            try
            {
                Farm.GetInstance(_context).Cultivations.Add(cultivation);
                _context.Cultivations.Add(cultivation);
                _context.SaveChanges();
                return Ok(cultivation);
            }
            catch { return BadRequest(); }
        }

        private List<CultivationViewModel> GetCultivationsFromDb(IEnumerable<Cultivation> leafs)
        {
            var result = new List<CultivationViewModel>();

            foreach (CultivationLeaf item in leafs.OfType<CultivationLeaf>())
            {
                if (item.Parent != null)
                    result.Add(new CultivationViewModel { Id = item.Id, CompositeId = item.Parent.Id, Grain = item.Grain.ToString(), Acreage = item.Acreage });

                else
                    result.Add(new CultivationViewModel { Id = item.Id, Grain = item.Grain.ToString(), Acreage = item.Acreage });
            }

            return result;
        }
    }
}