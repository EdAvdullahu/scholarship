using Microsoft.AspNetCore.Mvc;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Services.EmailServices;

namespace Scholarship_back.Services.EmailSender.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);
            return Ok();
        }
    }
}
