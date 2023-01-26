namespace Scholarship_back.Outer.Models
{
    public class FacultyPriority
    {
        public int Id { get; set; }
        public Subject? Subject { get; set; }
        public int SubjectId { get; set; }
        public FacultyType? FacultyType { get; set; }
        public int FacultyTypeId { get; set; }
        public int value { get; set; }
    }
}
