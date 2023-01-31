using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Dto
{
    public class ScholarshipReturnDto
    {
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
        public List<CriterionScholarship> CriteriaList { get; set; }
        public List<CategoryScholarship> CategoryList { get; set; }
        public int FacultyId { get; set; }
        public int TypeId { get; set; }
    }
}
