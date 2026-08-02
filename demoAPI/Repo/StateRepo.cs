using demoAPI.Interfaces;
using demoAPI.Models;
using demoAPI.Models.Dto;
using demoAPI.Models.Entity;
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

        public async Task<List<StateEntity>> GetAllStatesAsync()
        {
            return await _context.states.ToListAsync();
        }
        public async Task<StateEntity> AddNewState(StateEntity obj)

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
