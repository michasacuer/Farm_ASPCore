using Microsoft.AspNetCore.Mvc;
using Farm_ASPCore_Webapi.Models;

namespace Farm_ASPCore_Webapi.Controllers
{
    [Route("api/Stable")]
    [ApiController]
    public class StableController : ControllerBase
    {
        /// <summary>
        /// Get list of animals in stable
        /// </summary>
        // GET: api/Stable
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(Animals.GetAll());
        }

        /// <summary>
        /// Get animal by id
        /// </summary>
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