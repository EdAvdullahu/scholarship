using Scholarship_back.Outer.Dto;

namespace Scholarship_back.ScholarshipManager.Dto
{
    public class ScholarshipSimpleDto
    {
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
        public ListDto CriteriaList { get; set; }
        public int FacultyId { get; set; }
    }
}
