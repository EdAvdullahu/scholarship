using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Services
{
    public class FileUploader: FileUploaderInterface
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public DocumentList uploadApplicationFiles(List<FileUploadDto> files, int ScholarshipId, int DeadlienId, int StudentID)
        {
            DocumentService documentService = new DocumentService();
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "ApplicationFiles","Scholarship"+ScholarshipId,"Deadline"+DeadlienId,"Student"+StudentID);
            List<DocumentDto> tempDoc = new List<DocumentDto>();
            foreach (var file in files)
            {
                string filePath = Path.Combine(directoryPath,file.type+"");
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                filePath = Path.Combine(filePath, file.files.FileName);
                DocumentDto temp = new DocumentDto
                {
                    FilePath= filePath,
                    Type = file.type,
                };
                tempDoc.Add(temp);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.files.CopyTo(stream);
                }
            }
            return documentService.addDocuments(tempDoc);
        }
    }
}
