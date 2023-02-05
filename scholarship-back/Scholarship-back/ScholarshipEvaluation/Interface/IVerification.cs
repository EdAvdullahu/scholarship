using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipEvaluation.Interface
{
    public interface IVerification
    {
        public bool verifySubmition(ApplicationForm form);
    }
}
