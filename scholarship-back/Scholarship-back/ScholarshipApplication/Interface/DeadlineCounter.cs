using Scholarship_back.Data;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface DeadlineCounter
    {
        public void changeCounter(int Id, DataContext context);
    }
}
