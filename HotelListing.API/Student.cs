namespace HotelListing.API
{
    public class Student
    {

        public int studentId { get; set; }
        public int studentAge { get; set; }
        public string  firstName { get; set; }
        public string lastName { get; set; }    
        public string course { get; set; }  


        public Student(int studentID, string firstName, string lastName, string course)
        {
            this.studentId = studentID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.course = course;
          
        }

        public Student()
        {

        }

    }
}
