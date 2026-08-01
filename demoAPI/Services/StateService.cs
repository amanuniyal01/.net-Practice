using demoAPI.Interfaces;
using demoAPI.Models;

namespace demoAPI.Services
{
    public class StateService:IStateService
    {
        private readonly IStateRepo _stateRepository;
        public StateService(IStateRepo stateRepository){
            _stateRepository = stateRepository;
        }
        public async Task<List<StateModel>> GetAllStatesAsync()
        {
            return await _stateRepository.GetAllStatesAsync();
        }
        
        public async Task<StateModel> AddNewState(StateModel obj)
        {
            return await _stateRepository.AddNewState(obj);
        }
    }
}
