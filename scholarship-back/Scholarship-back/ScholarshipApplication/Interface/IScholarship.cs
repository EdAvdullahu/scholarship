using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface IScholarship
    {
        public Scholarship GetScholarshipById(int Id);
    }
}
