using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sep202022.Models;

namespace Sep202022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyncMySqlToMsSql : ControllerBase
    {
        [HttpGet]
        public List<Student> Sync()
        {
            var repository = new MyToMsqlSync();
            var students = repository.GetMySqlStudents();
            repository.SyncToMsSql(students);
            var mssqlstudents = new MsSqlRepository().GetStudents();
            return mssqlstudents;
        }
    }
}
