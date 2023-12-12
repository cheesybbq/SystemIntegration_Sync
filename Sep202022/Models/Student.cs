namespace Sep202022.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public int StudentNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public bool ForUpdating { get; set; }
    }
}
