using AutoMapper;
using demoAPI.Interfaces;
using demoAPI.Models;
using demoAPI.Models.Dto;
using demoAPI.Models.Entity;

namespace demoAPI.Services
{
    public class StateService:IStateService
    {
        private readonly IStateRepo _stateRepository;
        private readonly IMapper _mapper;
        public StateService(IStateRepo stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }
        public async Task<List<StateResponseDto>> GetAllStatesAsync()
        {
            var entity = await _stateRepository.GetAllStatesAsync();
            return _mapper.Map<List<StateResponseDto>>(entity);
        }
        
        public async Task<(bool Success, string Message)> AddNewState(StateRequestDto dto)

        {
            if (await _stateRepository.StateNameExistsAsync(dto.statename))
            {
                return (false, "State Already Exist!!");
            }
            var entity = _mapper.Map<StateEntity>(dto);
            await _stateRepository.AddNewState(entity);
            return (true , "State Added Successfully!!");
        }
    }
}
