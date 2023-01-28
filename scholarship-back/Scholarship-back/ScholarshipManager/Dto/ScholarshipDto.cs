using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipManager.Dto
{
    public class ScholarshipDto
    {
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
        public ListDto CriteriaList { get; set; }
        public ListDto CategoryList { get; set; }
        public FacultyInfo Faculty { get; set; }
        public int TypeId { get; set; }
    }
}
