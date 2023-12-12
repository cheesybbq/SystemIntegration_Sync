using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sep202022.Models;
namespace Sep202022.Controllers
{
    [Route("api/MsSqlStudents")]
    [ApiController]
    public class MsSqlStudents : ControllerBase
    {
        [HttpGet]
        public List<Student> Get()
        {
            var students = new MsSqlRepository().GetStudents();
            return students;
        }
        [HttpPost]
        public Student Add(Student student)
        {
            var repository = new MsSqlRepository();
            repository.AddStudent(student);
            return student;
        }

        [HttpPut]
        public Student Edit(string StudentID, Student student)
        {
            var repository = new MsSqlRepository();
            repository.UpdateStudent(StudentID, student);
            return student;
        }
    }
}
