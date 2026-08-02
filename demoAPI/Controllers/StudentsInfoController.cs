//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using demoAPI.Models;

//namespace demoAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentsInfoController : ControllerBase
//    {
//        [HttpGet]
//        public List<StudentModel> getAllStudents()
//        {
//            List<StudentModel> students = new List<StudentModel>();
//            StudentModel stud_1 = new StudentModel()
//            {
//                Name = "Aman",
//                Age = 20,
//                StudentGender = Gender.Male,
//                isActive = true
//            };
//            students.Add(stud_1);
//            StudentModel stud_2 = new StudentModel()
//            {
//                Name = "Anu",
//                Age = 21,
//                StudentGender=Gender.Male,
//                isActive = false
//            };
//            students.Add(stud_2);
//            StudentModel stud_3 = new StudentModel()
//            {
//                Name = "Ajay",
//                Age = 20,
//                StudentGender = Gender.Male,
//                isActive = true
//            };
//            students.Add(stud_3);
//        return students;
//        }
        
//    }
//}
