using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Dto
{
    public class ListsDto
    {
        public List<CriterionScholarship> CriteriaList { get; set; }
        public List<CategoryScholarship> CategoryList { get; set; }
    }
}
