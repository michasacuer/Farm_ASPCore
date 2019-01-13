using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Farm_ASPCore_Webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        // POST: api/Budget/value
        [HttpPost("{value}")]
        public IActionResult SetBudget(double value)
        {
            var budget = _context.Budgets.Find(1);
            budget.Value = value;
            _context.SaveChanges();
            return Ok(budget);
        }

    }
}
