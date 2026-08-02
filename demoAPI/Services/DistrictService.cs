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

        public async Task<(bool Success, string Message)> AddNewDistrict(DistrictRequestDto district)
        {
            var districtName = district.districtname.ToLower().Trim();
            var stateExists = await _stateRepository.StateExistsAsync(district.stateid);
            if (!stateExists)
            {
                return (false, $"There is no state present for stateId: {district.stateid}");
            }

            var districtExists = await _districtRepository.DistrictExistInState(district.stateid, districtName);
            if (districtExists)
            {
                return (false, "District already exists in this state");
            }

            await _districtRepository.AddNewDistrict(district);
            return (true, "District Added Successfully");
        }
        public async Task<List<DistrictWithState>> GetAllDistrictsWithStates()
        {
            return await _districtRepository.GetAllDistrictsWithStates();
        }


    }
    }

