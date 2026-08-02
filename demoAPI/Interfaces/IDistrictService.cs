using demoAPI.Models;

namespace demoAPI.Interfaces
{
    public interface IDistrictService
    {
        Task<List<DistrictModel>> GetAllDistricts();
        Task<(bool Success, string Message)> AddNewDistrict(DistrictModel district);
        Task<List<object>> GetAllDistrictsWithStates();
    }
}
