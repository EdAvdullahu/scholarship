using Scholarship_back.Data;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipManager.Services
{
    public class ScholarshipEngineer
    {
        ScholarshipBuilder _scholarshipBuilder;
        DataContext _context;
        public ScholarshipEngineer(ScholarshipBuilder scholarshipBuilder)
        {
            _scholarshipBuilder = scholarshipBuilder;
        }
        public Scholarship GetScholarship()
        {
            return _scholarshipBuilder.getScholarship();
        }
        public void constructScholarship(ScholarshipDto scholarshipDto)
        {
            _scholarshipBuilder.buildCriterion(scholarshipDto.CriteriaList);
            _scholarshipBuilder.buildFaculty(scholarshipDto.Faculty);
            _scholarshipBuilder.buildValue(scholarshipDto.Value);
            _scholarshipBuilder.buildDescription(scholarshipDto.Description);
            _scholarshipBuilder.buildCategory();
            _scholarshipBuilder.buildType();
        }

    }
}
