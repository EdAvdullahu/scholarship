namespace Scholarship_back.Outer.Models
{
    public class HighSchool
    {
        public int Id { get; set; }
        public string HighSchoolName { get; set; } = string.Empty;
        public string HighSchoolDescription { get; set; } = string.Empty;
        public HighSchoolType? HighSchoolType { get; set; }
        public int HighSchoolTypeId { get; set; }
    }
}
