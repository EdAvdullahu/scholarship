using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipManager.Interfaces
{
    public interface IScholarship
    {
        public Scholarship getScholarshipById(int id);
        public List<Criterion> getCriteriaById(int id);
    }
}
