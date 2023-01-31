using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipApplication.Models
{
    public class SubmitingDeadline
    {
        public int Id { get; set; }
        public Scholarship? Scholarship { get; set; }
        public int ScholarshipId { get; set; }
        public Faculty? Faculty { get; set; }
        public int FacultyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Counter { get; set; }
        public List<ApplicationForm> ApplicationForms { get; set; } = new List<ApplicationForm>();
    }
}