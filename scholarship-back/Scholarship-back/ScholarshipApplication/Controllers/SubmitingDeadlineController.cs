using Microsoft.AspNetCore.Mvc;
using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipApplication.Services.SubmitionDeadlineService;

namespace Scholarship_back.ScholarshipApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmitingDeadlineController : ControllerBase
    {
        private DataContext _context;
        public SubmitingDeadlineController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<SubmitingDeadline>>> Get()
        {
            return _context.SubmitingDeadlines.ToList();
        }
        [HttpPost]
        public async Task<ActionResult> create(SubmitingDeadlineDto request)
        {
            SubmitingDeadlineBuilder.ConstructDeadline(request, _context);
            return Ok("Submition created succsessfully");
        }
    }
}
