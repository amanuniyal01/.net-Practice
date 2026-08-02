using demoAPI.Models;
using demoAPI.Models.Dto;
using demoAPI.Models.Entity;

namespace demoAPI.Interfaces
{
    public interface IStateService
    {
        Task<List<StateResponseDto>> GetAllStatesAsync();
         Task<(bool Success, string Message)> AddNewState( StateRequestDto dto);
 
    }
}
