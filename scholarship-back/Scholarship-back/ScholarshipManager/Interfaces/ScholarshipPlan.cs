using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Interfaces
{
    public interface ScholarshipPlan
    {
        public CriterionScholarship setCriteria(int id);
        public CategoryScholarship setCategory(int id);
        public void setType(int id);
        public void setFaculty(int id);
        public void setValue(double val);
        public void setDescription(string description);
        public Scholarship getScholarship();
    }
}
