using demoAPI.Models;
using demoAPI.Models.Dto;
using demoAPI.Models.Entity;

namespace demoAPI.Interfaces
{
    public interface IStateRepo
    {
        Task<List<StateEntity>> GetAllStatesAsync();
        Task<StateEntity> AddNewState(StateEntity obj);
        Task<bool> StateExistsAsync(int stateId );
        Task<bool> StateNameExistsAsync(string statename);
    }
}
