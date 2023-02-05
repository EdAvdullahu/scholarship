using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Interfaces
{
    public interface FacultyInterface
    {
        public List<FacultyPriority> getPriorityList(int id);
    }
}
