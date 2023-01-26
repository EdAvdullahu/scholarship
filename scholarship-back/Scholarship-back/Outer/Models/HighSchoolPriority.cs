namespace Scholarship_back.Outer.Models
{
    public class HighSchoolPriority
    {
        public int Id { get; set; }
        public Subject? Subject { get; set; }
        public int SubjectId { get; set; }
        public HighSchoolType? HighSchoolType { get; set; }
        public int HighSchoolTypeId { get; set; }
        public int value { get; set; }
    }
}
