using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface SendEmailInterface
    {
        public void sendEmail(ApplicationForm application, int StudentId, DataContext _context);
    }
}
