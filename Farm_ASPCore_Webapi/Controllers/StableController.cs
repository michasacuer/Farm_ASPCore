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
    [Route("api/[controller]")]
    [ApiController]
    public class StableController : ControllerBase
    {
        // GET: api/Stable
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(Animals.GetAll());
        }

        // GET: api/Stable/5
        [HttpGet("{id}")]
        public IActionResult GetStable(int id)
        {
            var animal = Animals.GetAnimal(id);

            try   { return Ok(animal); }
            catch { return BadRequest(); }
        }
    }
}