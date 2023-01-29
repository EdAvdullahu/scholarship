using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Interface;

namespace Scholarship_back.Outer.Models
{
    public class Faculty: IFaculty
    {
        private DataContext _context;

        public Faculty(DataContext context)
        {
            _context = context;
        }

        public int Id { get; set; }
        public string FacultyName { get; set; } = string.Empty;
        public string FacultyDescription { get; set; } = string.Empty; 
        public University? University { get; set; }
        public int UniversityId { get; set; }
        public FacultyType? FacultyType { get; set; }    
        public int FacultyTypeId { get; set; }

        public Faculty GetFacultyById(int Id)
        {
            Faculty faculty = _context.Faculties.Where(x => x.Id == Id).FirstOrDefault();

            return faculty;
        }
    }
}
