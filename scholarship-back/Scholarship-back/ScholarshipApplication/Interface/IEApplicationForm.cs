using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface IEApplicationForm
    {
        public SubmitingDeadline getById(int id);
        public List<ApplicationForm> getApplicationsByDeadlineId(int id);
        public ApplicationForm getApplicationById(int id);
        public void changeStatus(int id, ApplicationStatus status, string message);
        public DocumentList getDocumentList(int id);

    }
}
