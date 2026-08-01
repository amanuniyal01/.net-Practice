using demoAPI.Models;

namespace demoAPI.Interfaces
{
    public interface IDistrictRepo
    {

       Task<List<DistrictModel>> GetAllDistricts();
        Task<DistrictModel> AddNewDistrict(DistrictModel district);
        Task<bool> DistrictExistInState(int stateId , string districtName);

        Task<List<object>> GetAllDistrictsWithStates();
    }
}
