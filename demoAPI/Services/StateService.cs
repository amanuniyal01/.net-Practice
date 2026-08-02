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
        
        public async Task<(bool Success, string Message)> AddNewState(StateModel obj)

        {
            if (await _stateRepository.StateNameExistsAsync(obj.statename))
            {
                return (false, "State Already Exist!!");
            }
            await _stateRepository.AddNewState(obj);
            return (true , "State Added Successfully!!");
        }
    }
}
