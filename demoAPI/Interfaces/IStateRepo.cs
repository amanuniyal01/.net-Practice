using demoAPI.Models;

namespace demoAPI.Interfaces
{
    public interface IStateRepo
    {
        Task<List<StateModel>> GetAllStatesAsync();
        Task<StateModel> AddNewState(StateModel obj);
    }
}
