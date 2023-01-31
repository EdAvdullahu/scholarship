using Microsoft.AspNetCore.Mvc;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Interfaces
{
    public interface ScholarshipBuilder
    {
        public void buildCriterion(ListDto list);
        public void buildCategory(ListDto list);
        public void buildType(int id);
        public void buildFaculty(int id);
        public Scholarship getScholarship();
        public void buildDescription(string description);
        public void buildValue(double value);
        public List<CriterionScholarship> GetCriterias();
        public List<CategoryScholarship> GetCategories();
    }
}
