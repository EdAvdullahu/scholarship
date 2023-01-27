using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipManager.Interfaces
{
    public interface ScholarshipBuilder
    {
        public void buildCriterion(ListDto list);
        public void buildCategory();
        public void buildType();
        public void buildFaculty(FacultyInfo faculty);
        public Scholarship getScholarship();
        public void buildDescription(string description);
        public void buildValue(double value);
    }
}
