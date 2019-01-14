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
            return Ok(GetAllCultivationsFromDb(Farm.GetInstance(_context).Cultivations.OfType<CultivationLeaf>()));
        }

        /// <summary>
        /// Splitting leaf in two parts
        /// </summary>
        // GET: api/Cultivation/Split/1/5
        [HttpGet("Split/{ratio}/{id}")]
        public IActionResult SplitCultivation(double ratio, int id)
        {
            var farm = Farm.GetInstance(_context);
            var leaf = farm.Cultivations.Find(c => c.Id == id);

            try
            {
                if (leaf.GetType() == typeof(CultivationLeaf))
                {
                    var (leaf1, leaf2, composite) = leaf.Split(ratio);
                    composite.Id = leaf.Id;   
                    farm.Cultivations.Remove(leaf);
                    farm.Cultivations.Add(leaf1);
                    farm.Cultivations.Add(leaf2);
                    farm.Cultivations.Add(composite);
                }   
            }
            catch { return BadRequest(); }

            //_context.SaveChanges();
            //farm.Cultivations = _context.Cultivations.ToList();
            return Ok(GetAllCultivationsFromDb(farm.Cultivations.OfType<CultivationLeaf>()));
        }

        /// <summary>
        /// Harvest leaf by id
        /// </summary>
        // GET: api/Cultivation/Harvest/5
        [HttpGet("Harvest/{id}")]
        public IActionResult Harvest(int id)
        {
            var leaf = Farm.GetInstance(_context).Cultivations.Find(c => c.Id == id);

            if (leaf.GetType() == typeof(CultivationLeaf))
                leaf.Harvest();

            else
                return BadRequest();

            var contextLeaf = _context.Cultivations.Find(leaf.Id);
            contextLeaf.Id = leaf.Id;
            _context.SaveChanges();

            return Ok(leaf);
        }

        /// <summary>
        /// Sow leaf by id
        /// </summary>
        // GET: api/Cultivation/Sow/Grain.Kind/5
        [HttpGet("Sow/{grain}/{id}")]
        public IActionResult Sow(int grain, int id)
        {
            var leaf = Farm.GetInstance(_context).Cultivations.Find(c => c.Id == id);

            if (leaf.GetType() == typeof(CultivationLeaf))
            {
                if (leaf.Grain == Grain.None)
                    leaf.Sow((Grain)grain);
                else
                    return BadRequest();
            }

            else
                return BadRequest();

            var contextLeaf = _context.Cultivations.Find(leaf.Id);
            contextLeaf.Id = leaf.Id;
            _context.SaveChanges();

            return Ok(leaf);
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

        private List<CultivationViewModel> GetAllCultivationsFromDb(IEnumerable<CultivationLeaf> leafs)
        {
            var result = new List<CultivationViewModel>();

            foreach (CultivationLeaf item in leafs)
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