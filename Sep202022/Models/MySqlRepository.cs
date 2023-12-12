using MySql.Data.MySqlClient;
namespace Sep202022.Models
{
    public class MySqlRepository
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string connectionstring = "server=localhost;port=3306;database=its406;username=root;password='';";
            MySqlConnection connection = new MySqlConnection(connectionstring); 
            connection.Open();
            MySqlCommand command = new MySqlCommand("select StudentID,StudentNumber,LastName,FirstName,Address,Birthday,Age from Student", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.Address = reader.GetString("Address");
                student.StudentNumber = reader.GetInt32("StudentNumber");
                student.LastName = reader.GetString("LastName");
                student.FirstName = reader.GetString("FirstName");
                student.Birthday = reader.GetDateTime("Birthday");
                student.Age = reader.GetInt32("Age");
                student.StudentID = reader.GetInt32("StudentID");
                students.Add(student);
            }
            return students;
        }
        public Student GetStudent(int StudentID)
        {
            Student student = new Student();
            string connectionstring = "server=localhost;port=3306;database=its406;username=root;password='';";
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select StudentID,StudentNumber,LastName,FirstName,Address,Birthday,Age from Student where StudentID=" + StudentID.ToString(), connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                student.Address = reader.GetString("Address");
                student.StudentNumber = reader.GetInt32("StudentNumber");
                student.LastName = reader.GetString("LastName");
                student.FirstName = reader.GetString("FirstName");
                student.Birthday = reader.GetDateTime("Birthday");
                student.Age = reader.GetInt32("Age");
                student.StudentID = reader.GetInt32("StudentID");
            }
            return student;
        }

        public List<Student> GetStudents(string name)
        {
            List<Student> students = new List<Student>();
            string connectionstring = "server=localhost;port=3306;database=its406;username=root;password='';";
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlCommand command = new MySqlCommand("select StudentID,StudentNumber,LastName,FirstName,Address,Birthday,Age from Student where lastname like '" + name +"%'", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student student = new Student();
                student.Address = reader.GetString("Address");
                student.StudentNumber = reader.GetInt32("StudentNumber");
                student.LastName = reader.GetString("LastName");
                student.FirstName = reader.GetString("FirstName");
                student.Birthday = reader.GetDateTime("Birthday");
                student.Age = reader.GetInt32("Age");
                student.StudentID = reader.GetInt32("StudentID");
                students.Add(student);
            }
            return students;
        }

        public void AddStudent(Student student)
        {
            List<Student> students = new List<Student>();
            string connectionstring = "server=localhost;port=3306;database=its406;username=root;password='';";
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlCommand command = new MySqlCommand("insert into Student(StudentNumber,LastName,FirstName,Address, Birthday, Age) values ('" +student.StudentNumber 
                +"','" + student.LastName +"','" + student.FirstName +"','" + student.Address + "','" + student.Birthday
                + "','" + student.Age+ "')", connection);
            var reader = command.ExecuteScalar();            
            
        }
    }
}
