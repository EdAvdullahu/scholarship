using Microsoft.AspNetCore.Mvc;
using Scholarship_back.Data;
using Scholarship_back.ScholarshipApplication.Dto;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;

namespace Scholarship_back.ScholarshipApplication.Services
{
    public class DocumentListService : DocumentListInterface
    {
        public DocumentList createDocumentList(List<Document> doc)
        {
            DocumentList temp = new DocumentList
            {
                Documents = doc
            };
            return temp;
        }
    }
}
