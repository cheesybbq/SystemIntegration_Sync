using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace Sep202022.Models
{
    public class MyToMsqlSync
    {
        public List<Student> GetMySqlStudents()
        {
            List<Student> students = new List<Student>();
            string connectionstring = "server=localhost;port=3306;database=its406;username=root;password='';";
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select StudentID,StudentNumber,LastName,FirstName,Address,Birthday,Age,StudentID from Student", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.StudentNumber = reader.GetInt32("StudentNumber");
                student.LastName = reader.GetString("LastName");
                student.FirstName = reader.GetString("FirstName");
                student.Address = reader.GetString("Address");
                student.Birthday = reader.GetDateTime("Birthday");
                student.Age = reader.GetInt32("Age");
                student.StudentID = reader.GetInt32("StudentID");

                string mssqlconnectionstring = @"Data Source=luweese\SQLExpress;Initial Catalog=ITS406;Persist Security Info=True;Integrated Security=true;Encrypt=false;";
                SqlConnection mssqlconnection = new SqlConnection(mssqlconnectionstring);
                mssqlconnection.Open();
                SqlCommand mssqlcommand = new SqlCommand("select StudentID,StudentNumber,LastName,FirstName,Address,Birthday,Age from Student where StudentNumber='" +
                    student.StudentNumber+ "'", mssqlconnection);
                var mssqlreader = mssqlcommand.ExecuteReader();
                if(mssqlreader.Read())
                {
                    student.ForUpdating = true;
                }
                else
                {
                    student.ForUpdating = false;
                }
                mssqlconnection.Close();
                students.Add(student);
            }
            return students;
        }

        public void SyncToMsSql(List<Student> students)
        {
            foreach(var student in students)
            {
                var repository = new MsSqlRepository();
                if(student.ForUpdating)
                {
                    repository.UpdateStudent(student.StudentNumber, student);
                }
                else
                {
                    repository.AddStudent(student);
                }

            }
        }
    }
}
