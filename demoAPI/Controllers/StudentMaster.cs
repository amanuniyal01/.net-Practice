using demoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using demoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace demoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMasterController : ControllerBase
    {
        private readonly StudentDbContext _dbContext;

        public StudentMasterController(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public List<StudentMasterModel> GetAllStudents()
        {
            return _dbContext.students.ToList();
        }
        [HttpPost ("addStudentData")]
        public StudentMasterModel AddStudent(StudentMasterModel obj)
        {
            _dbContext.students.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }

    }
}
