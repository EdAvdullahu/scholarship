using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Services
{
    public class BuilderService
    {
        private readonly DataContext _context;
        public BuilderService(DataContext context)
        {
            _context = context;
        }
        public ScholarshipReturnDto buildHighSchoolScholarship(ScholarshipSimpleDto scholarship)
        {
            ScholarshipDto scholarshipDto = new ScholarshipDto
            {
                CategoryList = getCategoriesForHSScholarship(),
                CriteriaList = scholarship.CriteriaList,
                FacultyId = scholarship.FacultyId,
                Value = scholarship.Value,
                Description = scholarship.Description,
                TypeId = 1
            };
            ScholarshipBuilder highSchoolScholarship = new HighSchoolScholarshipBuilder();
            ScholarshipEngineer engineer = new ScholarshipEngineer(highSchoolScholarship);
            engineer.constructScholarship(scholarshipDto);
            ScholarshipReturnDto temp = engineer.saveScholarship(_context);
            return temp;
        }
        private ListDto getCategoriesForHSScholarship()
        {
            List<int> tempCategories = new List<int>();
            List<string> requiredCategoies = new List<string>(){"Yearly"};
            Category tempCategory;
            for(int i = 0; i < requiredCategoies.Count; i++)
            {
                tempCategory = _context.Categories.Where(x => x.Name.Equals(requiredCategoies[i])).FirstOrDefault();
                tempCategories.Add(tempCategory.Id);
            }
            ListDto temp = new ListDto
            {
                list = tempCategories,
            };
            return temp;
        }
        /*private ScholarshipType getScholarshipType()
        {
            return _context.ScholarshipTypes.Where(x => x.Name.Equals("HighSchool")).FirstOrDefault();
        }*/
    }
}
