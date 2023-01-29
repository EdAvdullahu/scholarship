using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Interface;

namespace Scholarship_back.ScholarshipApplication.Models
{
    public class ApplicationForm
    {
        public int Id { get; set; }
        public DocumentList DocumentList { get; set; } = new DocumentList();
        public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
        public DateTime SubmittingTime { get; set; }
        public int StudentId { get; set; }

        public Student GetStudentById(IStudenti studentRepository)
        {
            return studentRepository.GetById(this.StudentId);
        }

        public void ChangeStatus(ApplicationStatus status)
        {
            this.Status = status;
        }

        public enum ApplicationStatus
        {
            Pending,
            Approved,
            Rejected
        }
    }
}
