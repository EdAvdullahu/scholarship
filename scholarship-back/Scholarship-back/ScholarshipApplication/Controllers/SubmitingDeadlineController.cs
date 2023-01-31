using Microsoft.AspNetCore.Mvc;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipApplication.Services.SubmitionDeadlineService;

namespace Scholarship_back.ScholarshipApplication.Controllers
{
    public class SubmitingDeadlineController : Controller
    {
        //private readonly ISubmitionDeadlineService _submitingDeadlineService;

        //public SubmitingDeadlineController(ISubmitionDeadlineService submitingDeadlineService)
        //{
        //    _submitingDeadlineService = submitingDeadlineService;
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateSubmitingDeadline(SubmitingDeadline submitingDeadline)
        //{
        //    var result = await _submitingDeadlineService.AddSubmitingDeadline(submitingDeadline);
        //    if (result)
        //    {
        //        return Ok("Submiting deadline created successfully");
        //    }
        //    return BadRequest("Failed to create submiting deadline");
        //}
    }
}
