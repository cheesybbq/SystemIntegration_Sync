using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace Sep202022.Models
{
    public class MsSqlRepository
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string connectionstring = @"Data Source=luweese\SQLExpress;Initial Catalog=ITS406;Persist Security Info=True;Integrated Security=true;Encrypt=false;";
            SqlConnection connection = new SqlConnection(connectionstring); 
            connection.Open();
            SqlCommand command = new SqlCommand("select StudentID,StudentNumber,LastName,FirstName,Address,Birthday,Age from Student", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.Address = reader.GetString(5);
                student.StudentNumber = reader.GetInt32(1);
                student.LastName = reader.GetString(2);
                student.FirstName = reader.GetString(3);
                student.Birthday = reader.GetDateTime(4);
                student.Age = reader.GetInt32(0);
                student.StudentID = reader.GetInt32(0);
                students.Add(student);
            }
            return students;
        }
        public void AddStudent(Student student)
        {
            List<Student> students = new List<Student>();
            string connectionstring = @"Data Source=luweese\SQLExpress;Initial Catalog=ITS406;Persist Security Info=True;Integrated Security=true;Encrypt=false;";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Student(StudentNumber,LastName,FirstName,Address, Birthday, Age) values ('" + student.StudentNumber
                + "','" + student.LastName + "','" + student.FirstName + "','" + student.Address + "','" + student.Birthday
                + "','" + student.Age + "')", connection);
            var reader = command.ExecuteScalar();

        }
        public void UpdateStudent(int StudentNumber, Student student)
        {
            List<Student> students = new List<Student>();
            string connectionstring = @"Data Source=luweese\SQLExpress;Initial Catalog=ITS406;Persist Security Info=True;Integrated Security=true;Encrypt=false;";
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand("update Student set LastName='" +student.LastName 
                + "', FirstName='"+student.FirstName 
                +"', Address='" +student.Address 
                + "', Birthday='" + student.Birthday.ToString("yyyy-MM-dd")
                + "', Age='" + student.Age
                + "' where StudentNumber='" + StudentNumber +"'", connection);
            var reader = command.ExecuteScalar();
        }
    }
}
