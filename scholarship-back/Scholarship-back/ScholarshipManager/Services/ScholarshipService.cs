using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Models.Helpers;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.Outer.Dto;

namespace Scholarship_back.ScholarshipManager.Services
{
    public class ScholarshipService: ScholarshipPlan
    {
        Scholarship _scholarship;
        public ScholarshipService()
        {
            _scholarship = new Scholarship();
        }

        public CategoryScholarship setCategory(int id)
        {
            CategoryScholarship categoryScholarship = new()
            {
                ScholarshipId = _scholarship.Id,
                CategoryId = id
            };
            return categoryScholarship;
        }

        public CriterionScholarship setCriteria(int id)
        {
            CriterionScholarship criterionScholarship = new()
            {
                ScholarshipId = _scholarship.Id,
                CriterionId = id
            };
            return criterionScholarship;
        }

        public void setDescription(string description)
        {
            _scholarship.Description = description;
        }

        public void setFaculty(int id)
        {
            _scholarship.FacultyId = id;
        }

        public void setType(int id)
        {
            _scholarship.ScholarshipTypeId = id;
        }

        public void setValue(double val)
        {
            _scholarship.Value = val;
        }

        public Scholarship getScholarship()
        {
            return _scholarship;
        }
    }
}
