using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Dto
{
    public class ApplicationFormDto
    {
        public DocumentList DocumentList { get; set; } = new DocumentList();
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public DateTime SubmittingTime { get; set; }
        public int StudentId { get; set; }

        public enum ApplicationStatus
        {
            Pending,
            Approved,
            Rejected
        }
    }
}
