using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface ApplicationInterface
    {
        public void constructApplication(ApplicationFormSaveDto application);
        public ApplicationForm getApplication();
    }
}
