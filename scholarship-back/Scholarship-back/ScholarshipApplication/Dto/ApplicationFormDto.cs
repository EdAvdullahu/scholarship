using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Dto
{
    public class ApplicationFormDto
    {
        public List<IFormFile> files { get; set; }
        public List<DocumentType> FileType { get; set; }
        public DateTime SubmittingTime { get; set; }
        public int StudentId { get; set; }
        public int SubmitingDeadlineId { get; set; }
    }
}
