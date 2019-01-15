using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;
using Farm_ASPCore_Webapi.Models.Enums;
using System;
using System.Collections.Generic;
using Farm_ASPCore_Webapi.Helpers;

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

            var summary = new Summary{ SummaryDate = DateTime.Now };
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

        // GET api/Summary/list
        [HttpGet]
        public IActionResult GetListOfMemento()
        {
            try
            {
                var list = new List<SummaryViewModel>();
                for (int i = 0; i < Caretaker.Instance.GetMementoLength; i++)
                    list.Add(new SummaryViewModel { Id = i + 1, SummaryDate = Caretaker.Instance.GetDate(i) });
                return Ok(list);
            }
            catch { return BadRequest(new BadRequestViewModel { Message = "Error while loading memento list" }); }

        }

        /// <summary>
        /// Populating machines with strategy
        /// </summary>
        private void StrategyPopulate()
        {
            foreach (Machine machine in _context.Machines)
            {
                if (machine.MappedStrategy == Strategy.Cultivation)
                    machine.Strategy = new CultivationStrategy();

                else
                    machine.Strategy = new FarmStrategy();
            }
        }
    }
}