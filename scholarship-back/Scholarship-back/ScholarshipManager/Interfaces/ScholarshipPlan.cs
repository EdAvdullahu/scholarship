using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipManager.Interfaces
{
    public interface ScholarshipPlan
    {
        public void setCriteria(int id);
        public void setCategory(int id);
        public void setType(int id);
        public void setFaculty(FacultyInfo faculty);
        public void setValue(double val);
        public void setDescription(string description);
    }
}
