using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface SubmitingDeadlinePlan
    {
        public void setScholarship(int id);
        public void setStartDate(DateTime time);
        public void setEndDate(DateTime time);
        public SubmitingDeadline getDeadline();
    }
}
