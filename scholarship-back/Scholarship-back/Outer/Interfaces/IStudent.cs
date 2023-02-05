using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Interfaces
{
    public interface IStudent
    {
        public StudentBasicInfo getById(int id, DataContext context);
        public Student getStudnetById(int id);
    }
}
