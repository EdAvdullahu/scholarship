using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Dto
{
    public class FacultyDto
    {
        public string FacultyName { get; set; } = string.Empty;
        public string FacultyDescription { get; set; } = string.Empty;
        public int UniversityId { get; set; }
        public int FacultyTypeId { get; set; }
    }
}
