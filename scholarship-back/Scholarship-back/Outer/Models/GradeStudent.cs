namespace Scholarship_back.Outer.Models
{
    public class GradeStudent
    {
        public int Id { get; set; }
        public Student? Student { get; set; }
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }
        public int GradeId { get; set; }
    }
}
