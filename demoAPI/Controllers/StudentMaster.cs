using demoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public IActionResult GetAllStudents()
        {
            var studentData = _dbContext.students.ToList();
            if (studentData == null)
            {
                return NotFound();
            }
            return Ok(studentData);
        }
        [HttpPost ("addStudentData")]
        public IActionResult AddStudent(StudentMasterModel obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.students.Add(obj);
            _dbContext.SaveChanges();
            return Created("Student added Successfully",obj);
        }

        [HttpPut("editStudentData/{studId}")]
        public IActionResult EditStudentData(int studId, StudentMasterModel obj)
        {
            var studentData = _dbContext.students
                .SingleOrDefault(x => x.studid == studId);

            if (studentData == null)
            {
                return NotFound();
            }

            studentData.studname = obj.studname;
            studentData.age = obj.age;

            _dbContext.SaveChanges();

            return Ok(studentData);
        }
    }
}
