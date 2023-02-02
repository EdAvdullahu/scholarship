using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Services.ApplicationFormService
{
    public interface IApplicationFormService
    {
        void CreateApplicationForm(ApplicationFormDto application);
    }
}
