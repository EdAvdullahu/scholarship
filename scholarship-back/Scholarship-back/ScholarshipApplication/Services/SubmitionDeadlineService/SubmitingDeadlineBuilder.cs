using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Services.SubmitionDeadlineService
{
    public class SubmitingDeadlineBuilder
    {
        public static SubmitingDeadline ConstructDeadline(SubmitingDeadlineDto deadline, DataContext context)
        {
            if(deadline == null)
            {
                return null;
            }
            SubmitionDeadlineService _deadlineService = new SubmitionDeadlineService();
            _deadlineService.setStartDate(deadline.StartDate);
            _deadlineService.setEndDate(deadline.EndDate);
            _deadlineService.setScholarship(deadline.ScholarshipId);
            saveDeadline(_deadlineService.getDeadline(),context);
            return _deadlineService.getDeadline();
        }
        private static void saveDeadline(SubmitingDeadline deadline, DataContext context)
        {
            context.SubmitingDeadlines.Add(deadline);
            context.SaveChanges();
        }

    }
}
