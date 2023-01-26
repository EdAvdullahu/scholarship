namespace Scholarship_back.Outer.Models
{
    public class Student: User
    {
        public HighSchool? HighSchool { get; set; }
        public int HighSchoolId { get; set; }  
    }
}
