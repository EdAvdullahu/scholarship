namespace Scholarship_back.Outer.Models
{
    public class GradeStudentSummary
    {
        public int Id { get; set; }
        public Subject? Subject { get; set; }
        public int SubjectId { get; set; }
        public int Value { get; set; }
        public Student? Student { get; set; }
        public int StudentId { get; set; }
    }
}
