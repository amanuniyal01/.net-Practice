using demoAPI.Interfaces;
using demoAPI.Models;

namespace demoAPI.Services
{
    public class DistrictService:IDistrictService
    {
        public readonly IDistrictRepo _districtRepository;
        private readonly IStateRepo _stateRepository;

        public DistrictService(IDistrictRepo districtRepository, IStateRepo stateRepository)
        {
            _districtRepository = districtRepository;
            _stateRepository = stateRepository;
        }

        public async Task<List<DistrictModel>> GetAllDistricts()
        {
            return await _districtRepository.GetAllDistricts();
        }

        public async Task<(bool Success, string Message)> AddNewDistrict(DistrictModel district)
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
        public async Task<List<object>> GetAllDistrictsWithStates()
        {
            return await _districtRepository.GetAllDistrictsWithStates();
        }


    }
    }

