using Scholarship_back.Data;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Services.SubmitionDeadlineService
{
    public class SubmitionDeadlineService : SubmitingDeadlinePlan
    {
        private SubmitingDeadline _deadline;
        public SubmitionDeadlineService()
        {
            _deadline = new SubmitingDeadline();
        }

        public SubmitingDeadline getDeadline()
        {
            return _deadline;
        }

        public void setEndDate(DateTime time)
        {
            _deadline.EndDate = time;
        }

        public void setScholarship(int id)
        {
            _deadline.ScholarshipId = id;
        }

        public void setStartDate(DateTime time)
        {
            _deadline.StartDate = time;
        }
    }
}
