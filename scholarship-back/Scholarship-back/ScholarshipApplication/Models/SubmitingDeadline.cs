using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipApplication.Models
{
    public class SubmitingDeadline
    {
        public int Id;
        public int ScholarshipId;
        public int FacultyId;
        public DateTime startDate;
        public DateTime endDate;
        public int counter;
        public List<ApplicationForm> Applications { get; set; } = new List<ApplicationForm>();

        public Faculty GetById(IFaculty facultyRepository)
        {
            return facultyRepository.GetFacultyById(this.FacultyId);
        }
        public Scholarship GetById(IScholarship scholarshipRepository)
        { 
            return scholarshipRepository.GetScholarshipById(this.ScholarshipId);    
        }
        public void AddSubmition(ApplicationForm app)
        {
            Applications.Add(app);
            counter++;
        }

    }
}
