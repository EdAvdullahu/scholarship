using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipApplication.Services.EmailSender;
using Scholarship_back.Services.EmailSender.Dto;

namespace Scholarship_back.ScholarshipApplication.Services
{
    public class EmailSenderService:SendEmailInterface
    {
        private IEmailService _email;
        private IStudent _student;

        public EmailSenderService(IEmailService email, IStudent student)
        {
            _email = email;
            _student = student;
        }
        private string formatEmail(ApplicationForm form)
        {
            return "your application: </br>" +
                "<table>" +
                "<tr><th>Application ID<th><td>" + form.ApplicationStatus + "</td></tr>" +
                "<tr><th>Student Id<th><td>" + form.StudentId + "</td></tr>" +
                "<tr><th>Status<th><td>" + form.ApplicationStatus + "</td></tr>" +
                "</table>" +
                "</br>" +
                "was submited successfully on: " + form.SubmittingTime;
        }

        void SendEmailInterface.sendEmail(ApplicationForm application, int StudentId, DataContext _context)
        {
            StudentBasicInfo tempStudent = _student.getById(StudentId, _context);
            EmailDto emailTemplate = new EmailDto
            {
                To = tempStudent.email,
                Subject = "Application form",
                Body = "Dear " + tempStudent.name + ", we can inform you that " + formatEmail(application)
            };
            _email.SendEmail(emailTemplate);
        }
    }
}
