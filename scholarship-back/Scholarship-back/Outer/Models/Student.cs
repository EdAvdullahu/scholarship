using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Interface;

namespace Scholarship_back.Outer.Models
{
    public class Student: User, IStudenti
    {
        public HighSchool? HighSchool { get; set; }
        public int HighSchoolId { get; set; }

        private readonly DataContext _context;
        public Student(DataContext context)
        {
            _context = context;
        }
        public Student GetById(int id) 
        {
            Student student = _context.Students.Where(x => x.Id == Id).FirstOrDefault();
            
            return student;
        }
    }
}
