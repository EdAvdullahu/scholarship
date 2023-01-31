namespace Scholarship_back.ScholarshipApplication.Services.ApplicationFormService
{
    public interface IApplicationFormService
    {
        void CreateApplicationForm(int documentListId, int studentId, int submitingDeadlineId);
    }
}
