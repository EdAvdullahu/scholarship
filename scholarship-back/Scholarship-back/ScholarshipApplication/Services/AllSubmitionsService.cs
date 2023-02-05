using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipApplication.Services.EmailSender;
using Scholarship_back.Services.EmailSender.Dto;

namespace Scholarship_back.ScholarshipApplication.Services
{
    public class AllSubmitionsService : IEApplicationForm
    {
        private readonly DataContext _context;
        private readonly IEmailService _email;
        public AllSubmitionsService(DataContext context, IEmailService serv)
        {
            _context = context;
            _email = serv;
        }

        public void changeStatus(int id, ApplicationStatus status, string message)
        {
            ApplicationForm temp = _context.ApplicationForms.Find(id);
            temp.ApplicationStatus=status;
            sendEmail(temp, message);
        }

        public ApplicationForm getApplicationById(int id)
        {
            return _context.ApplicationForms.Find(id);
        }

        public SubmitingDeadline getById(int id)
        {
            return _context.SubmitingDeadlines.Find(id);
        }

        public DocumentList getDocumentList(int id)
        {
            return _context.DocumentLists.Find(id);
        }
        public void sendEmail(ApplicationForm form, string reason)
        {
            Student tempS = _context.Students.Find(form.StudentId);
            if (tempS == null)
            {
                return;
            }
            _email.SendEmail(formatEmail(tempS.Email, FormatMessage(form, reason, tempS), "APPLICATION STATUS CHANGE"));
        }
        private string FormatMessage(ApplicationForm form, string reason, Student student)
        {
            return "";
        }
        private EmailDto formatEmail(string to, string message, string header)
        {
            var email = new EmailDto
            {
                To = to,
                Body = message,
                Subject = header,
            };
            return email;
        }

        public List<ApplicationForm> getApplicationsByDeadlineId(int id)
        {
            return _context.ApplicationForms.Where(x => x.SubmitingDeadlineId == id).ToList();
        }
    }
}
