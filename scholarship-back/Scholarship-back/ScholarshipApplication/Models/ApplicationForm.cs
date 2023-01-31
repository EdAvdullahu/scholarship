using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Interface;

namespace Scholarship_back.ScholarshipApplication.Models
{
    public class ApplicationForm
    {
        public int Id { get; set; }
        public DocumentList? DocumentList { get; set; }
        public int DocumentListId { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; } = ApplicationStatus.Pending;
        public DateTime SubmittingTime { get; set; }
        public Student? Student { get; set; }   
        public int? StudentId { get; set; }
        public SubmitingDeadline? SubmittingDeadline { get; set; } 
        public int SubmitingDeadlineId { get; set; }
    }
}
