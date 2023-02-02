using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface DocumentsInterface
    {
        public DocumentList addDocuments(List<DocumentDto> documents);
    }
}
