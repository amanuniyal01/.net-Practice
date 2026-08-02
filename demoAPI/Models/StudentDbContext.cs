using demoAPI.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace demoAPI.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
        //public DbSet<StudentMasterModel> students { get; set; }
        public DbSet<StateEntity> states { get; set; }
        public DbSet<DistrictEntity> districts { get; set; }
    }
}
