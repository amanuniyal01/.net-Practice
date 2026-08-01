using demoAPI.Repo;

namespace demoAPI.Services
{
    public class DistrictService
    {
        public readonly DistrictRepository _districtRepository;

        public DistrictService(DistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }
    }
}
