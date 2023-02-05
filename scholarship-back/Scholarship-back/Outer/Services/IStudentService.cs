using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Services
{
    public class IStudentService : IStudent
    {
        private readonly DataContext _dataContext;
        public IStudentService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public StudentBasicInfo getById(int id, DataContext context)
        {
            throw new NotImplementedException();
        }

        public Student getStudnetById(int id)
        {
            return _dataContext.Students.Find(id);
        }
    }
}
