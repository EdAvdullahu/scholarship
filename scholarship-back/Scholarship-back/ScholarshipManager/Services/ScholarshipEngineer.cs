using Microsoft.EntityFrameworkCore;
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
        private Scholarship GetScholarship()
        {
            return _scholarshipBuilder.getScholarship();
        }
        private List<CategoryScholarship> getCategories()
        {
            return _scholarshipBuilder.GetCategories();
        }
        private List<CriterionScholarship> getCriterions()
        {
            return _scholarshipBuilder.GetCriterias();
        }
        public void constructScholarship(ScholarshipDto scholarshipDto)
        {
            _scholarshipBuilder.buildFaculty(scholarshipDto.FacultyId);
            _scholarshipBuilder.buildValue(scholarshipDto.Value);
            _scholarshipBuilder.buildDescription(scholarshipDto.Description);
            _scholarshipBuilder.buildCriterion(scholarshipDto.CriteriaList);
            _scholarshipBuilder.buildCategory(scholarshipDto.CategoryList);
            _scholarshipBuilder.buildType(scholarshipDto.TypeId);
        }

        public ScholarshipReturnDto saveScholarship(DataContext context)
        {
            Scholarship temp = GetScholarship();
            if (temp == null)
            {
                return null;
            }
            DataContext _context = context;
            ScholarshipReturnDto scholarshipDto = new ScholarshipReturnDto
            {
                CriteriaList = getCriterions(),
                CategoryList = getCategories(),
                FacultyId = temp.FacultyId,
                Description = temp.Description,
                Value = temp.Value,
                TypeId = temp.ScholarshipTypeId,
            };
            _context.Scholarships.Add(temp);
            _context.SaveChanges();
            saveCategories(getCategories(), temp.Id, _context);
            saveCriteria(getCriterions(), temp.Id, _context);
            return scholarshipDto;
        }
        private void saveCategories(List<CategoryScholarship> list, int id,DataContext context)
        {
            for (int i = 0; i < list.Count; i++)
            {
                CategoryScholarship temp = new CategoryScholarship
                {
                    ScholarshipId = id,
                    CategoryId = list[i].CategoryId,
                };
                context.ScholarshipCategories.Add(temp);
                context.SaveChanges();
            }

        }
        private void saveCriteria(List<CriterionScholarship> list, int id, DataContext context)
        {
            for (int i = 0; i < list.Count; i++)
            {
                CriterionScholarship temp = new CriterionScholarship
                {
                    ScholarshipId = id,
                    CriterionId = list[i].CriterionId,
                };
                context.ScholarshipCriterias.Add(temp);
                context.SaveChanges();
            }
        }
    }
}
