using Scholarship_back.Data;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Services
{
    public class ScholarshipEngineer
    {
        ScholarshipBuilder _scholarshipBuilder;
        public ScholarshipEngineer(ScholarshipBuilder scholarshipBuilder)
        {
            _scholarshipBuilder = scholarshipBuilder;
        }
        public Scholarship GetScholarship()
        {
            return _scholarshipBuilder.getScholarship();
        }
        public ListsDto getLists()
        {
            ListsDto temp = new ListsDto
            {
                CategoryList = _scholarshipBuilder.GetCategories(),
                CriteriaList = _scholarshipBuilder.GetCriterias()
            };
            return temp;
        }
        public void constructScholarship(ScholarshipDto scholarshipDto)
        {
            _scholarshipBuilder.buildFaculty(scholarshipDto.Faculty);
            _scholarshipBuilder.buildValue(scholarshipDto.Value);
            _scholarshipBuilder.buildDescription(scholarshipDto.Description);
            _scholarshipBuilder.buildCriterion(scholarshipDto.CriteriaList);
            _scholarshipBuilder.buildCategory(scholarshipDto.CategoryList);
            _scholarshipBuilder.buildType(scholarshipDto.TypeId);
        }

    }
}
