using Microsoft.EntityFrameworkCore;
using Scholarship_back.Outer.Models;
using Scholarship_back.Data;

namespace Scholarship_back.ScholarshipApplication.Services
{
    public class StudentRepository
    {
            private readonly DataContext _context;

            public StudentRepository(DataContext context)
            {
                _context = context;
            }

            public Student GetStudentById(int id)
            {
                return _context.Students.Where(x=>x.Id==id).FirstOrDefault();
            }
    }
}
