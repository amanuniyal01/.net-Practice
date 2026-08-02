//using demoAPI.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//namespace demoAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentMasterController : ControllerBase
//    {
//        private readonly StudentDbContext _dbContext;

//        public StudentMasterController(StudentDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        [HttpGet]
//        [Route("GetAllStudents")]
//        public async Task<IActionResult> GetAllStudents()
//        {
//            var studentData =await  _dbContext.students.ToListAsync();
//            if (!studentData.Any())
//            {
//                return NotFound();
//            }
//            return Ok(studentData);
//        }
//        [HttpPost ("addStudentData")]
//        public async Task<IActionResult> AddStudent(StudentMasterModel obj)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            await _dbContext.students.AddAsync(obj);
//           await  _dbContext.SaveChangesAsync();
//            return Created("Student added Successfully",obj);
//        }

//        [HttpPut("editStudentData/{studId}")]
//        public async Task<IActionResult> EditStudentData(int studId, StudentMasterModel obj)
//        {
//            var studentData =await  _dbContext.students
//                .SingleOrDefaultAsync(x => x.studid == studId);

//            if (studentData == null)
//            {
//                return NotFound();
//            }

//            studentData.studname = obj.studname;
//            studentData.age = obj.age;

//           await  _dbContext.SaveChangesAsync();

//            return Ok(studentData);
//        }
//    }
//}
