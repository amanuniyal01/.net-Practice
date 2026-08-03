using demoAPI.Models;
using demoAPI.Models.Dto;
namespace demoAPI.Interfaces
{
    public interface IDistrictService
    {
        Task<List<DistrictResponseDto>> GetAllDistricts(string? search);
        Task<(bool Success, string Message)> AddNewDistrict(DistrictRequestDto district);
        Task<List<DistrictWithState>> GetAllDistrictsWithStates();
        Task<(DistrictResponseDto? District,string? message)>GetDistrictById(int id);

    }
}
