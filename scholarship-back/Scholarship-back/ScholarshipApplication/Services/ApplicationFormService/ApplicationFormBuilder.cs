using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Services.ApplicationFormService
{
    public class ApplicationFormBuilder : ApplicationInterface
    {
        private ApplicationForm _applicationForm;
        public ApplicationFormBuilder()
        {
            _applicationForm = new ApplicationForm();
        }
        public void constructApplication(ApplicationFormSaveDto application)
        {
            _applicationForm.SubmitingDeadlineId = application.SubmitingDeadlineId;
            _applicationForm.DocumentListId = application.DocumentistId;
            _applicationForm.StudentId = application.StudentId;
            _applicationForm.ApplicationStatus = ApplicationStatus.Pending;
            _applicationForm.SubmittingTime = DateTime.Now;
        }

        public ApplicationForm getApplication()
        {
            return _applicationForm;
        }
    }
}
