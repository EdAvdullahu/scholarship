using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Services.SubmitionDeadlineService
{
    public class DeadlineManagerService: DeadlineCounter, DeadlineGetInfo
    {
        public void changeCounter(int Id, DataContext context)
        {
            /*SubmitingDeadline tempDeadline = context.SubmitingDeadlines.Find(Id);
            if (tempDeadline == null) return;
            tempDeadline.Counter++;
            context.SaveChanges();*/
        }

        public SubmitingDeadlineDto getById(int id, DataContext context)
        {
            SubmitingDeadline temp = context.SubmitingDeadlines.Find(id);
            SubmitingDeadlineDto tempReturn = new SubmitingDeadlineDto
            {
                EndDate = temp.EndDate,
                StartDate = temp.StartDate,
                ScholarshipId = temp.ScholarshipId,
                FacultyId = 1
            };
            return tempReturn;
        }
    }
}
