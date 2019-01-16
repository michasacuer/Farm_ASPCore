using Farm_ASPCore_Webapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Farm_ASPCore_Webapi.Controllers
{
    [Route("api/Budget")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly FarmDbContext _context;

        public BudgetController(FarmDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Sets budget for whole farm
        /// </summary>
        // POST: api/Budget/value
        [HttpPost("{value}")]
        public IActionResult SetBudget(double value)
        {
            var budget = _context.Budgets.SingleOrDefault();
            budget.Value = value;
            _context.SaveChanges();
            return Ok(budget);
        }
    }
}
