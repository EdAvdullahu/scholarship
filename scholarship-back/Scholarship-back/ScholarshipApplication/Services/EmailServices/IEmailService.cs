using Scholarship_back.ScholarshipApplication.Dto;

namespace Scholarship_back.ScholarshipApplication.Services.EmailServices
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}

