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
        public Scholarship buildHighSchoolScholarship(ScholarshipSimpleDto scholarship)
        {
            IFaculty infoS = new IFaculty(_context);
            FacultyInfo fInfo = infoS.FacultyToInfo(scholarship.FacultyId);
            if (fInfo == null)
            {
                return null;
            }
            ScholarshipDto scholarshipDto = new ScholarshipDto
            {
                CategoryList = getCategoriesForScholarship(),
                CriteriaList = scholarship.CriteriaList,
                Faculty = fInfo,
                Value = scholarship.Value,
                Description = scholarship.Description,
                TypeId = 1
            };
            ScholarshipBuilder highSchoolScholarship = new HighSchoolScholarshipBuilder();
            ScholarshipEngineer engineer = new ScholarshipEngineer(highSchoolScholarship);
            engineer.constructScholarship(scholarshipDto);
            Scholarship temp = engineer.GetScholarship();
            saveScholarship(temp);
            ListsDto tempLists = engineer.getLists();
            saveCategories(tempLists.CategoryList, temp.Id);
            saveCriteria(tempLists.CriteriaList, temp.Id);
            return IScholarship.IdentityInsert(temp);
        }
        public void saveScholarship(Scholarship req)
        {
            _context.Scholarships.Add(req);
            _context.SaveChanges();
        }
        private ListDto getCategoriesForScholarship()
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
        private void saveCategories(List<CategoryScholarship> list, int id)
        {
            for(int i = 0; i < list.Count; i++)
            {
                CategoryScholarship temp = new CategoryScholarship
                {
                    ScholarshipId = id,
                    CategoryId = list[i].CategoryId,
                };
                _context.ScholarshipCategories.Add(temp);
                _context.SaveChanges();
            }
            
        }
        private void saveCriteria(List<CriterionScholarship> list, int id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                CriterionScholarship temp = new CriterionScholarship
                {
                    ScholarshipId = id,
                    CriterionId = list[i].CriterionId,
                };
                _context.ScholarshipCriterias.Add(temp);
                _context.SaveChanges();
            }
        }
    }
}
