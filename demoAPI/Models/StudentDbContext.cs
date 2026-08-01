using Microsoft.EntityFrameworkCore;

namespace demoAPI.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
        public DbSet<StudentMasterModel> students { get; set; }
        public DbSet<StateModel> states { get; set; }
        public DbSet<DistrictModel> districts { get; set; }
    }
}
