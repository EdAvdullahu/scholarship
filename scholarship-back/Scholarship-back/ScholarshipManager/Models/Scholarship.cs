using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Models
{
    public class Scholarship : ScholarshipPlan
    {
        public int Id { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
        public ScholarshipType? ScholarshipType { get; set; }
        public int ScholarshipTypeId { get; set; }
        public int FacultyId { get; set; }
        public int UniversityId { get; set; }
        public int FacultyTypeId { get; set; }

        public CategoryScholarship setCategory(int id)
        {
            CategoryScholarship categoryScholarship = new CategoryScholarship
            {
                ScholarshipId = Id,
                CategoryId = id
            };
            return categoryScholarship;
        }

        public CriterionScholarship setCriteria(int id)
        {
            CriterionScholarship criterionScholarship = new CriterionScholarship
            {
                ScholarshipId = Id,
                CriterionId = id
            };
            return criterionScholarship;
        }

        public void setFaculty(FacultyInfo faculty)
        {
            FacultyId = faculty.FacultyId;
            FacultyTypeId = faculty.FacultyTypeId;
            UniversityId = faculty.UniversityId;
        }

        public void setType(int id)
        {
            ScholarshipTypeId = id;
        }
        public void setValue(double val)
        {
            Value = val;
        }
        public void setDescription(string description)
        {
            Description = description;
        }
    }
}
