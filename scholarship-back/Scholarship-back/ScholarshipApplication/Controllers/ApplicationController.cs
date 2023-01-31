using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipApplication.Services.ApplicationFormService;
using Scholarship_back.ScholarshipManager.Models;

namespace Scholarship_back.ScholarshipApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationFormService _applicationFormService;

        public ApplicationController(IApplicationFormService applicationFormService)
        {
            _applicationFormService = applicationFormService;
        }

        [HttpPost]
        public IActionResult AddApplicationForm(int documentListId, int studentId, int submitingDeadlineId)
        {
            var applicationForm = new ApplicationForm();
            _applicationFormService.CreateApplicationForm(documentListId, studentId, submitingDeadlineId);
            
            return Ok("ApplicationForm created successfully");
        }

    }
}
