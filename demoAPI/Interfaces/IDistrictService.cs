using demoAPI.Models;
using demoAPI.Models.Dto;
namespace demoAPI.Interfaces
{
    public interface IDistrictService
    {
        Task<List<DistrictResponseDto>> GetAllDistricts();
        Task<(bool Success, string Message)> AddNewDistrict(DistrictRequestDto district);
        Task<List<DistrictWithState>> GetAllDistrictsWithStates();
    }
}
