using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Services
{
    public class FacultyScholarshipBuilder
    {
        private Scholarship _scholarship;
        public List<CategoryScholarship> buildCategory(ListDto list)
        {
            List<CategoryScholarship> categories = new List<CategoryScholarship>();
            CategoryScholarship temp;
            for (int i = 0; i < list.getLength(); i++)
            {
                temp = _scholarship.setCategory(list.getByIndex(i));
                categories.Add(temp);
            }
            return categories;
        }

        public List<CriterionScholarship> buildCriterion(ListDto list)
        {
            List<CriterionScholarship> criterions = new List<CriterionScholarship>();
            CriterionScholarship temp;
            for (int i = 0; i < list.getLength(); i++)
            {
                temp = _scholarship.setCriteria(list.getByIndex(i));
                criterions.Add(temp);
            }
            return criterions;
        }

        public void buildFaculty(FacultyInfo faculty)
        {
            _scholarship.setFaculty(faculty);
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
            return _scholarship;
        }
    }
}
