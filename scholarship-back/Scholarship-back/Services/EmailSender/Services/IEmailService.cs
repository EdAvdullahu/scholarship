using Scholarship_back.Services.EmailSender.Dto;

namespace Scholarship_back.ScholarshipApplication.Services.EmailSender
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}

