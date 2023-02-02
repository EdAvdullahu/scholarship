using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Dto
{
    public class DocumentDto
    {
        public DocumentType Type { get; set; }
        public string FilePath { get; set; }
    }
}
