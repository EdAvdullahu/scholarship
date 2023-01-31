using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Services.SubmitionDeadlineService
{
    public class SubmitionDeadlineService
    {
        //private readonly SubmitingDeadlineRepository _submitingDeadlineRepository;

        //public SubmitionDeadlineService(SubmitingDeadlineRepository submitingDeadlineRepository)
        //{
        //    _submitingDeadlineRepository = submitingDeadlineRepository;
        //}

        //public async Task<bool> AddSubmitingDeadline(SubmitingDeadline submitingDeadline)
        //{
        //    _submitingDeadlineRepository.Add(submitingDeadline);
        //    var result = await _submitingDeadlineRepository.SaveChangesAsync();
        //    return result > 0;
        //}

        //public void AddSubmition(ApplicationForm app)
        //{
        //    ApplicationForms.Add(app);
        //}
        //public void CreateApplication(Student student)
        //{
        //    ApplicationForms.Add(new ApplicationForm
        //    {
        //        Student = student.Id
        //        SubmitingDeadline = submiting
        //        StudentId = student.Id
        //    });
        //}
        //public void ApproveApplication(int id)
        //{
        //    var app = ApplicationForms.FirstOrDefault(a => a.Id == id);
        //    if (app != null)
        //    {
        //        app.Status = Status.Approved;
        //    }
        //}
        //public void RejectApplication(int id)
        //{
        //    var app = this.ApplicationForms.FirstOrDefault(a => a.Id == id);
        //    if (app != null)
        //    {
        //        app.Status = Statuses.Rejected;
        //    }
        //}
    }
}
