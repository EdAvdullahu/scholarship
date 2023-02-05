using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Services
{
    public class StudentService : IStudent
    {
        public StudentBasicInfo getById(int id, DataContext context)
        {
            Student temp = context.Students.Where(x=>x.Id==id).FirstOrDefault();
            if (temp == null)
            {
                return null;
            }
            StudentBasicInfo studentBasicInfo = new StudentBasicInfo
            {
                email=temp.Email,
                name=temp.Name,
            };
            return studentBasicInfo;
        }

        public Student getStudnetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
