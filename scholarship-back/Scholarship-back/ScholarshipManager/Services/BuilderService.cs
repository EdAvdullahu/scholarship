using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipManager.Services
{
    public class BuilderService
    {
        private IFaculty _faculty;
        public BuilderService(DataContext context)
        {
            _faculty = new IFaculty(context);
        }
        public Scholarship buildHighSchoolScholarship(ScholarshipSimpleDto scholarship)
        {
            ScholarshipDto scholarshipDto = new ScholarshipDto
            {
                CriteriaList = scholarship.CriteriaList,
                Faculty = _faculty.FacultyToInfo(scholarship.FacultyId),
                Value = scholarship.Value,
                Description = scholarship.Description
            };
            ScholarshipBuilder highSchoolScholarship = new HighSchoolScholarshipBuilder();
            ScholarshipEngineer engineer = new ScholarshipEngineer(highSchoolScholarship);
            engineer.constructScholarship(scholarshipDto);
            Scholarship temp = engineer.GetScholarship();
            return temp;
        }
    }
}
