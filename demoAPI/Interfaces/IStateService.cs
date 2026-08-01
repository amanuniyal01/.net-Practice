using demoAPI.Models;

namespace demoAPI.Interfaces
{
    public interface IStateService
    {
        Task<List<StateModel>> GetAllStatesAsync();
         Task<StateModel> AddNewState( StateModel obj);
    }
}
