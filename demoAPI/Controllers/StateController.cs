using demoAPI.Interfaces;
using demoAPI.Models;
using demoAPI.Models.Dto;
using demoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        private readonly IDistrictService _districtService;
        public StateController(IStateService stateService, IDistrictService districtService)
        {
            _stateService = stateService;
            _districtService = districtService;
        }

        [HttpGet("GetAllStates")]
        public async Task<IActionResult> GetAllStates()
        {
            var stateData = await _stateService.GetAllStatesAsync();
            if (!stateData.Any())
            {
                return NoContent();
            }

            return Ok(stateData);
        }

        [HttpPost("AddStateData")]
        public async Task<IActionResult> AddStateData(StateRequestDto obj)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

         var(success,message)=   await _stateService.AddNewState(obj);
            if (!success)
                return BadRequest(message);

            return Ok(message);
        }

        [HttpGet("GetAllDistricts")]
        public async Task<IActionResult> GetAllDistrict()
        {
            var districtData = await _districtService.GetAllDistricts();

            if (!districtData.Any())
            {
                return NoContent();
            }

            return Ok(districtData);
        }
     
        [HttpPost("AddDistrict")]
        public async Task<IActionResult> AddDistrict(DistrictRequestDto obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (success, message) = await _districtService.AddNewDistrict(obj); 

            if (!success)
                return BadRequest(message);

            return Ok(message);
        }

        [HttpGet ("GetAllDistrictWithStates")]
        public async Task<IActionResult> GetAllDistrictWithStates()
        {
            var list = await _districtService.GetAllDistrictsWithStates();
            return Ok(list);
        }


    }
}
