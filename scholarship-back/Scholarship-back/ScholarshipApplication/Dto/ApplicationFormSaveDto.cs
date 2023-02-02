using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Dto
{
    public class ApplicationFormSaveDto
    {
        public int StudentId { get; set; }
        public int SubmitingDeadlineId { get; set; }
        public int DocumentistId { get; set; }
    }
}
