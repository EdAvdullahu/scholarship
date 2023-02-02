using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Dto;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface DeadlineGetInfo
    {
        public SubmitingDeadlineDto getById(int id, DataContext context);
    }
}
