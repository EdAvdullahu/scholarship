using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Models;
using static Scholarship_back.ScholarshipApplication.Models.ApplicationForm;

namespace Scholarship_back.ScholarshipApplication.Dto
{
    public class SubmitingDeadlineDto
    {
        public int ScholarshipId { get; set; }
        public int FacultyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
