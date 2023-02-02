using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Interface
{
    public interface DocumentListInterface
    {
        public DocumentList createDocumentList(List<Document> documents);
    }
}
