using demoAPI.Interfaces;
using demoAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demoAPI.Repo
{
    public class StateRepo : IStateRepo
    {
        private readonly StudentDbContext _context;

        public StateRepo(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<List<StateModel>> GetAllStatesAsync()
        {
            return await _context.states.ToListAsync();
        }
        public async Task<StateModel> AddNewState(StateModel obj)

        {
            _context.states.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
        public async Task<bool> StateExistsAsync(int stateId )
        {
            return await _context.states.AnyAsync(m => m.stateid == stateId );
        }
       
           public async Task<bool> StateNameExistsAsync(string stateName)
        {
            return await _context.states.AnyAsync(m =>
                m.statename.ToLower().Trim() == stateName.ToLower().Trim());
        }
    }
 
}
