using Microsoft.AspNetCore.Mvc;
using Scholarship_back.Services.EmailSender.Dto;
using Scholarship_back.ScholarshipApplication.Services.EmailSender;

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
