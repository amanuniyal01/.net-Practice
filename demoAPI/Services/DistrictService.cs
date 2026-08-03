using AutoMapper;
using demoAPI.Interfaces;
using demoAPI.Models;
using demoAPI.Models.Dto;
using demoAPI.Models.Entity;

namespace demoAPI.Services
{
    public class DistrictService:IDistrictService
    {
        public readonly IDistrictRepo _districtRepository;
        private readonly IStateRepo _stateRepository;
        private readonly IMapper _mapper;

        public DistrictService(IDistrictRepo districtRepository, IStateRepo stateRepository , IMapper mapper)
        {
            _districtRepository = districtRepository;
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        public async Task<List<DistrictResponseDto>> GetAllDistricts()
        {
            var entities = await _districtRepository.GetAllDistricts();
            return _mapper.Map<List<DistrictResponseDto>>(entities);
        }

        public async Task<(bool Success, string Message)> AddNewDistrict(DistrictRequestDto dto)
        {

            var districtName = dto.districtname.ToLower().Trim();
            var stateExists = await _stateRepository.StateExistsAsync(dto.stateid);
            if (!stateExists)
            {
                return (false, $"There is no state present for stateId: {dto.stateid}");
            }

            var districtExists = await _districtRepository.DistrictExistInState(dto.stateid, districtName);
            if (districtExists)
            {
                return (false, "District already exists in this state");
            }

            var entity = _mapper.Map<DistrictEntity>(dto);
            await _districtRepository.AddNewDistrict(entity);
          
            return (true, "District Added Successfully");
        }
        public async Task<List<DistrictWithState>> GetAllDistrictsWithStates()
        {
            return await _districtRepository.GetAllDistrictsWithStates();
        }

        public async Task<(DistrictResponseDto? District,string? message)> GetDistrictById(int id)
        {
            var entity = await _districtRepository.GetDistrictById(id);

            if (entity == null)
                return (null , "No district found for this id!!");   

          var dto=_mapper.Map<DistrictResponseDto>(entity);
            return (dto, null);
        }
    }

    
    }

