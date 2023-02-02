using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using Org.BouncyCastle.Bcpg;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipApplication.Services.ApplicationFormService;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.Services.EmailSender.Dto;
using IEmailService = Scholarship_back.ScholarshipApplication.Services.EmailSender.IEmailService;

namespace Scholarship_back.ScholarshipApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IApplicationFormService _applicationInterface;

        public ApplicationController(DataContext context, IApplicationFormService applicationInterface)
        {
            _context = context;
            _applicationInterface = applicationInterface;
        }
        [HttpGet]
        public async Task<ActionResult<List<ApplicationForm>>> Get()
        {
            return Ok(await _context.ApplicationForms.ToListAsync());
        }
        [HttpGet("documents")]
        public async Task<ActionResult<List<Document>>> GetDocuments()
        {
            return Ok(await _context.Documents.ToListAsync());
        }
        [HttpGet("document-list")]
        public async Task<ActionResult<List<DocumentList>>> GetDocumentList()
        {
            return Ok(await _context.DocumentLists.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> AddApplicationForm([FromForm]ApplicationFormDto request)
        {
            _applicationInterface.CreateApplicationForm(request);
            return Ok("Application");
        }

    }
}
