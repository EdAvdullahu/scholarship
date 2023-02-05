using Scholarship_back.Data;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipEvaluation.Interface;

namespace Scholarship_back.ScholarshipEvaluation.Service
{
    public class Verification : IVerification
    {
        private readonly IStudent _student;
        private readonly DataContext _context;

        public Verification(IStudent student, DataContext context)
        {
            _student = student;
            _context = context;
        }

        public bool verifySubmition(ApplicationForm form)
        {
            if(form == null)
            {
                return false;
            }
            int id = getStudentId(form);
            if(id == 0)
            {
                return false;
            }
            if (verifyStudent(id))
            {
                return false;
            }
            return false;
        }
        private bool verifyStudent(int id)
        {
            var student = _student.getById(id, _context);
            return student == null;
        }
        private int getStudentId(ApplicationForm form)
        {
            if (form.StudentId != null)
            {
                return form.StudentId.Value;
            }
            return 0;
        }
    }
}
