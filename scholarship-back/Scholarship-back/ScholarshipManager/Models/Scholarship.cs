using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Interfaces;

namespace Scholarship_back.ScholarshipManager.Models
{
    public class Scholarship : ScholarshipPlan
    {
        private int Id { get; set; }
        private string Description { get; set; } = string.Empty;
        private double Value { get; set; }
        private List<Category>? Categories { get; set; }
        private List<int> CategoryList { get; set; }
        private List<Criterion>? Criterias { get; set; }
        private List<int> CriteriaList { get; set; }
        private ScholarshipType? ScholarshipType { get; set; }
        private int ScholarshipTypeId { get; set; }
        private FacultyInfo Faculty { get; set; }

        public void setCategory(int id)
        {
            CategoryList.Add(id);
        }

        public void setCriteria(int id)
        {
            CriteriaList.Add(id);
        }

        public void setFaculty(FacultyInfo faculty)
        {
            Faculty = faculty;
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
