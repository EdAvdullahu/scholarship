using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Services.ApplicationFormService
{
    public class ApplicationFormService:IApplicationFormService
    {
        private readonly DataContext _context;

        public ApplicationFormService(DataContext context)
        {
            _context = context;
        }

        public void CreateApplicationForm(int documentListId, int studentId, int submitingDeadlineId)
        {
            var documentList = _context.DocumentLists.Find(documentListId);
            var student = _context.Students.Find(studentId);
            var submitingDeadline = _context.SubmitingDeadlines.Find(submitingDeadlineId);

            var applicationForm = new ApplicationForm
            {
                DocumentList = documentList,
                DocumentListId = documentListId,
                Student = student,
                StudentId = studentId,
                SubmittingDeadline = submitingDeadline,
                //status mungon
                SubmitingDeadlineId = submitingDeadlineId,
                SubmittingTime = DateTime.Now
            };

            _context.ApplicationForms.Add(applicationForm);
            _context.SaveChanges();
        }
    }
}
