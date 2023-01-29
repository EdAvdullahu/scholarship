namespace Scholarship_back.ScholarshipApplication.Models
{
    public class Document
    {
        public int Id { get; set; }
        public DocumentType? TypeDoc { get; set; }
        public string Content { get; set; }= string.Empty;
    }
}
