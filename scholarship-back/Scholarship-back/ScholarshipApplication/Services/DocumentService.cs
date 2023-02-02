using Org.BouncyCastle.Asn1.Mozilla;
using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Services
{
    public class DocumentService : DocumentsInterface
    {
        public DocumentList addDocuments(List<DocumentDto> documents)
        {
            DocumentListService service = new DocumentListService();
            DocumentList list = service.createDocumentList(convertoToList(documents));
            return list;
        }
        private List<Document> convertoToList(List<DocumentDto> docs)
        {
            List<Document> documents = new List<Document>();
            docs.ForEach((doc) =>
            {
                Document temp = new Document
                {
                    FilePath = doc.FilePath,
                    Type = doc.Type
                };
                documents.Add(temp);
            });
            return documents;
        }
    }
}
