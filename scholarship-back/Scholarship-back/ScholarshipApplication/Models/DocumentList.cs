namespace Scholarship_back.ScholarshipApplication.Models
{
    public class DocumentList
    {
        public int documentListId { get; set; }
        public List<Document> Documents { get; set; } = new List<Document>();

        public void AddDocument(Document document)
        {
            Documents.Add(document);
        }

        public void RemoveDocument(Document document)
        {
            Documents.Remove(document);
        }

        public Document GetDocumentById(int id)
        {
            return Documents.FirstOrDefault(d => d.Id == id);
        }
    }
}
