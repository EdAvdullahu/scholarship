using Scholarship_back.Data;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Services
{
    public class FacultyService : FacultyInterface
    {
        private readonly DataContext _context;
        public FacultyService(DataContext context)
        {
            _context = context;
        }

        public List<FacultyPriority> getPriorityList(int id)
        {
            int TypeId = _context.Faculties.Find(id).FacultyTypeId;
            return _context.FacultyPriorities.Where(x=>x.FacultyTypeId==TypeId).ToList();    
        }
    }
}
