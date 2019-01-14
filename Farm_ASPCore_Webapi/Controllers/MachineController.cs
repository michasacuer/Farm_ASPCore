using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Farm_ASPCore_Webapi.Models;
using Farm_ASPCore_Webapi.Models.Enums;
using Farm_ASPCore_Webapi.Helpers;

namespace Farm_ASPCore_Webapi.Controllers
{
    [Route("api/Machine")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly FarmDbContext _context;

        public MachineController(FarmDbContext context)
        {
            _context = context;
        }

        // GET: api/Machine
        [HttpGet]
        public IActionResult AcquireMachines()
        {
            try
            {
                if (!MachineObjectPool.Instance.IsPoolPopulated())
                    MachineObjectPool.Instance.PopulatePool(_context.Machines);

                return Ok(MachineObjectPool.Instance.AcquireMachine());
            }
            catch { return NotFound(new NotFoundViewModel { Message = "Pool Empty!" }); }
        }

        // GET: api/Machine/5
        [HttpGet("{id}")]
        public IActionResult ReleaseMachine(int id)
        {
            try
            {
                var machine = _context.Machines.Find(id);
                MachineObjectPool.Instance.ReleaseMachine(machine);
                return Ok(machine);
            }

            catch { return BadRequest(new BadRequestViewModel { Message = "Pool full, PANIC" }); }
        }

        //POST: api/Machine/5/Strategy/0
        [HttpPost("{id}/Strategy/{strategy}")]
        public IActionResult ChangeStrategy(int id, int strategy)
        {
            var machine = _context.Machines.Find(id);
            machine.MappedStrategy = (Strategy)strategy;
            _context.SaveChanges();
            return Ok(machine);
        }
    }
}