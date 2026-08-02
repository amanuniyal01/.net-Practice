using demoAPI.Models;

namespace demoAPI.Interfaces
{
    public interface IStateService
    {
        Task<List<StateModel>> GetAllStatesAsync();
         Task<(bool Success, string Message)> AddNewState( StateModel obj);
 
    }
}
