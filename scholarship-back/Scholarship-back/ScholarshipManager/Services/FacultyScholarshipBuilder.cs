using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Services
{
    public class FacultyScholarshipBuilder
    {
        private ScholarshipService _scholarship;
        List<CriterionScholarship> _criterions = new List<CriterionScholarship>();
        List<CategoryScholarship> _categories = new List<CategoryScholarship>();
        public FacultyScholarshipBuilder()
        {
            _scholarship = new ScholarshipService();
        }
        public void buildCategory(ListDto list)
        {
            CategoryScholarship temp;
            for (int i = 0; i < list.getLength(); i++)
            {
                temp = _scholarship.setCategory(list.getByIndex(i));
                _categories.Add(temp);
            }
        }

        public void buildCriterion(ListDto list)
        {
            CriterionScholarship temp;
            for (int i = 0; i < list.getLength(); i++)
            {
                temp = _scholarship.setCriteria(list.getByIndex(i));
                _criterions.Add(temp);
            }
        }

        public void buildFaculty(int id)
        {
            _scholarship.setFaculty(id);
        }

        public void buildType(int id)
        {
            _scholarship.setType(id);
        }
        public void buildDescription(string description)
        {
            _scholarship.setDescription(description);
        }
        public void buildValue(double value)
        {
            _scholarship.setValue(value);
        }
        public Scholarship getScholarship()
        {
            return _scholarship.getScholarship();
        }
        public List<CriterionScholarship> GetCriterias()
        {
            return _criterions;
        }
        public List<CategoryScholarship> GetCategories()
        {
            return _categories;
        }
    }
}
