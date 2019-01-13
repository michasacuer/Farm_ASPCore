using System.Linq;
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

        /// <summary>
        /// Get summary cost of managing Farm
        /// </summary>
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
            summary.Budget = _context.Budgets.SingleOrDefault().Value;
            summary.GetSummary(farm);

            return Ok(summary);
        }

        /// <summary>
        /// Saving summary to Memento
        /// </summary>
        // POST: api/Summary
        [HttpPost]
        public IActionResult SaveSummary(Summary summary)
        {
            var originator = Summary.Instance;
            var caretaker = Caretaker.Instance;

            originator.SetState(summary);
            caretaker.Add(originator.Save());

            return Ok(summary);
        }

        /// <summary>
        /// Restore summary raport from Memento by id
        /// </summary>
        // GET: api/Summary/1
        [HttpGet("{id}")]
        public IActionResult RestoreSummary(int id)
        {
            Summary.Instance.GetStateFromMemento(Caretaker.Instance.Get(id - 1));
            return Ok(Summary.Instance.GetState());
        }

        /// <summary>
        /// Populating machines with strategy
        /// </summary>
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