using demoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly StudentDbContext _dbContext;
        public StateController(StudentDbContext dbContext)

        {
            _dbContext = dbContext;
        }

        [HttpGet("getAllStates")]
        public async Task<IActionResult> GetAllStates()
        {
            var stateData = await _dbContext.states.ToListAsync();

            if (!stateData.Any())
            {
                return NoContent();
            }

            return Ok(stateData);
        }

        [HttpPost ("addStateData")]
        public async Task<IActionResult> AddStateData( StateModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stateDataAdded = await _dbContext.states.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return Created("State added Successfully", obj);

        }

    }
}
