using Scholarship_back.Data;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Services
{
    public class HighSchoolService : HighSchoolInterface
    {
        private readonly DataContext _context;
        public HighSchoolService(DataContext context)
        {
            _context = context;
        }
        public List<HighSchoolPriority> getPriority(int id)
        {
            int typeId = _context.HighSchools.Where(x=>x.Id==id).Select(x=>x.HighSchoolTypeId).First();
            return _context.HighSchoolPriorities.Where(x=>x.HighSchoolTypeId==typeId).ToList();
        }

        public List<GradeStudentSummary> getStudentGrades(int id)
        {
            return _context.GradeStudentSummaries.Where(x=>x.StudentId==id).ToList();
        }
    }
}
