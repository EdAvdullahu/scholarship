using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipApplication.Services.EmailSender;
using Scholarship_back.ScholarshipApplication.Services.SubmitionDeadlineService;
using Scholarship_back.Services.EmailSender.Dto;
using static System.Net.Mime.MediaTypeNames;
using EmailService = Scholarship_back.ScholarshipApplication.Services.EmailSender.EmailService;
using IEmailService = Scholarship_back.ScholarshipApplication.Services.EmailSender.IEmailService;

namespace Scholarship_back.ScholarshipApplication.Services.ApplicationFormService
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly DataContext _context;
        private readonly FileUploader _fileUploader;
        private readonly ApplicationFormBuilder _application;
        private readonly EmailService _emailService;

        public ApplicationFormService(DataContext context,IWebHostEnvironment _webHostEnvironment, IConfiguration config)
        {
            _context = context;
            _fileUploader = new FileUploader(_webHostEnvironment);
            _application = new ApplicationFormBuilder();
            _emailService = new EmailService(config);
        }

        public void CreateApplicationForm(ApplicationFormDto application)
        {
            int ScholarshipId = getScholarshipId(application.SubmitingDeadlineId);
            List<FileUploadDto> tempList = convertToFileUploadDto(application.files, application.FileType);
            DocumentList DocumentList = _fileUploader.uploadApplicationFiles(tempList, ScholarshipId, application.SubmitingDeadlineId, application.StudentId);
            saveDocuments(DocumentList);
            ApplicationFormSaveDto applicationFormSaveDto = new ApplicationFormSaveDto
            {
                DocumentistId = DocumentList.Id,
                SubmitingDeadlineId = application.SubmitingDeadlineId,
                StudentId = application.StudentId,
            };
            _application.constructApplication(applicationFormSaveDto);
            saveApplication(_application.getApplication());
        }
        private void saveDocuments(DocumentList docs)
        {
            docs.Documents.ForEach((doc) =>
            {
                _context.Documents.Add(doc);
                _context.SaveChanges();
            });
            _context.DocumentLists.Add(docs);
            _context.SaveChanges();
        }
        private void saveApplication(ApplicationForm app)
        {
            _context.ApplicationForms.Add(app);
            _context.SaveChanges();
            sendEmail(app);
            DeadlineManagerService dead = new DeadlineManagerService();
            dead.changeCounter(app.SubmitingDeadlineId, _context);
        }
        private int s(int id)
        {
           return new DeadlineManagerService().getById(id, _context).ScholarshipId;
        }
        private void sendEmail(ApplicationForm form)
        {
            EmailDto tempE = new EmailDto
            {
                To = _context.Students.Find(form.StudentId).Email,
                Subject = "SCHOLARSHIP APPLICATION",
                Body = formatEmail(form)
            };
            _emailService.SendEmail(tempE);
        }
        private string formatEmail(ApplicationForm form)
        {
            return "your application: </br>" +
                "<table>" +
                "<tr><th>Application ID<th><td>" + form.Id + "</td></tr>" +
                "<tr><th>Student Id<th><td>" + form.StudentId + "</td></tr>" +
                "<tr><th>Status<th><td>" + form.ApplicationStatus + "</td></tr>" +
                "</table>" +
                "</br>" +
                "was submited successfully on: " + form.SubmittingTime;
        }
        private List<FileUploadDto> convertToFileUploadDto(List<IFormFile> files, List<DocumentType> types)
        {
            List<FileUploadDto> result = new List<FileUploadDto>();
            for(int i = 0; i < types.Count; i++)
            {
                FileUploadDto temp = new FileUploadDto
                {
                    files = files[i],
                    type = types[i]
                };
                result.Add(temp);
            }
            return result;
        }
        private int getScholarshipId(int id)
        {
            return _context.SubmitingDeadlines.Where(x => x.Id == id).FirstOrDefault().ScholarshipId;
        }
    }
}
