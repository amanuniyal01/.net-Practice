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
        public DbSet<StateEntity> state { get; set; }
        public DbSet<DistrictEntity> district { get; set; }
    }
}
