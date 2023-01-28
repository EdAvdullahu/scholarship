using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipManager.Interfaces
{
    public class IScholarship
    {
        public static Scholarship IdentityInsert(Scholarship sch)
        {
            Scholarship scholarship = new Scholarship
            {
                UniversityId = sch.UniversityId,
                FacultyId = sch.FacultyId,
                FacultyTypeId = sch.FacultyTypeId,
                Value = sch.Value,
                Description = sch.Description,
            };
            return scholarship;
        }
    }
}
