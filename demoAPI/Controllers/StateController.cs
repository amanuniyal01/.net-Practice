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

        [HttpGet("GetAllStates")]
        public async Task<IActionResult> GetAllStates()
        {
            var stateData = await _dbContext.states.ToListAsync();

            if (!stateData.Any())
            {
                return NoContent();
            }

            return Ok(stateData);
        }

        [HttpPost ("AddStateData")]
        public async Task<IActionResult> AddStateData( StateModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stateDataAdded = await _dbContext.states.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return Ok("State Added Successfully");

        }
        [HttpGet("GetAllDistricts")]
        public async Task<IActionResult> GetAllDistrict()
        {
            var districtData = await _dbContext.districts.ToListAsync();

            if (!districtData.Any())
            {
                return NoContent();
            }

            return Ok(districtData);
        }
        [HttpPost("AddDistrict")]
        public async Task<IActionResult> AddDistrict(DistrictModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // 🔹 Normalize input
            var districtName = obj.districtname.ToLower().Trim();

            // 🔹 Check duplicate in SAME state
            var districtExists = await _dbContext.districts
                .AnyAsync(m =>
                    m.stateid == obj.stateid &&
                    m.districtname.ToLower().Trim() == districtName
                );
            var sateExists = await _dbContext.states.AnyAsync(

                m => m.stateid == obj.stateid);

            if (!sateExists)
            {
                return BadRequest($"There is no state presnet for stateId : {obj.stateid}");
            }

            if (districtExists)
            {
                return BadRequest("District already exists in this state");
            }

            // 🔹 Insert
            await _dbContext.districts.AddAsync(obj);
            await _dbContext.SaveChangesAsync();

            return Ok("District Added Successfully");
        }


    }
}
