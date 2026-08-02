using demoAPI.Interfaces;
using demoAPI.Models;
using demoAPI.Models.Dto;
using demoAPI.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace demoAPI.Repo
{
    public class DistrictRepository : IDistrictRepo
    {
        private readonly StudentDbContext _context;
        public DistrictRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<List<DistrictEntity>> GetAllDistricts()
        {
            var districtData = await _context.districts.ToListAsync();
            return districtData;
        }

        public async Task<DistrictRequestDto> AddNewDistrict(DistrictEntity district)
        {
            await _context.districts.AddAsync(district);
            await _context.SaveChangesAsync();
            return district;
        }

        public async Task<bool> DistrictExistInState(int stateId, string districtName)
        {
            return await _context.districts.AnyAsync(m =>
            m.stateid == stateId &&
            m.districtname.ToLower().Trim() == districtName);
        }
         
        public async Task<List<DistrictWithState>> GetAllDistrictsWithStates()
        {
            var list = await (from district in _context.districts
                              join state in _context.states on district.stateid equals state.stateid
                              select new DistrictWithState
                              {
                                  districtId = district.districtid,
                                  districtName = district.districtname,
                                  stateName = state.statename
                              }).ToListAsync<object>();

            return list;
        }
    }
}
