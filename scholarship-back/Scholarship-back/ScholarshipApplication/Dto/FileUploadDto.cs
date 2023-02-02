using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Dto
{
    public class FileUploadDto
    {
        public IFormFile files { get; set; }
        public DocumentType type { get; set; }

    }
}
