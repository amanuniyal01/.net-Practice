using demoAPI.Models;
using demoAPI.Models.Dto;
using demoAPI.Models.Entity;

namespace demoAPI.Interfaces
{
    public interface IStateService
    {
        Task<List<StateEntity>> GetAllStatesAsync();
         Task<(bool Success, string Message)> AddNewState( StateDto obj);
 
    }
}
