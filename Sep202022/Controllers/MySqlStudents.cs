using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sep202022.Models;
namespace Sep202022.Controllers
{
    [Route("api/MySqlStudents")]
    [ApiController]
    public class MySqlStudents : ControllerBase
    {
        [HttpGet]
        public List<Student> Get()
        {
            var students = new MySqlRepository().GetStudents();
            return students;
        }
        [HttpGet]
        [Route("LastName/{name}")]
        public List<Student> Get(string name) 
        {
            var students = new MySqlRepository().GetStudents(name);
            return students;
        }
        [HttpGet]
        [Route("{StudentID}")]
        public Student Get(int StudentID)
        {
            var student = new MySqlRepository().GetStudent(id);
            return student;
        }

        [HttpPost]
        public Student Add(Student student)
        {
            var repository = new MySqlRepository();
            repository.AddStudent(student);
            return student;
        }
             
    }
}
