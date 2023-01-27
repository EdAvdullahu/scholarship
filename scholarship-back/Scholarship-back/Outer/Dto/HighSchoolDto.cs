using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Dto
{
    public class HighSchoolDto
    {
        public string HighSchoolName { get; set; } = string.Empty;
        public string HighSchoolDescription { get; set; } = string.Empty;
        public int HighSchoolTypeId { get; set; }
    }
}
