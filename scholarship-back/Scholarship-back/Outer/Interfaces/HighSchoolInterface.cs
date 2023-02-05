using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Interfaces
{
    public interface HighSchoolInterface
    {
        public List<HighSchoolPriority> getPriority(int id);
        public List<GradeStudentSummary> getStudentGrades(int id);
    }
}
