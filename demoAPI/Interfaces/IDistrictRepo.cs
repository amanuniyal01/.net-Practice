using demoAPI.Models;
using demoAPI.Models.Dto;
using demoAPI.Models.Entity;

namespace demoAPI.Interfaces
{
    public interface IDistrictRepo
    {

       Task<List<DistrictEntity>> GetAllDistricts();
        Task<DistrictRequestDto> AddNewDistrict(DistrictEntity district);
        Task<bool> DistrictExistInState(int stateId , string districtName);

        Task<List<DistrictWithState>> GetAllDistrictsWithStates();
    }
}
