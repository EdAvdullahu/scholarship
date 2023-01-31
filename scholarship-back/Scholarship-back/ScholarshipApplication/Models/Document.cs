namespace Scholarship_back.ScholarshipApplication.Models
{
    public class Document
    {
            public int Id { get; set; }
            public DocumentType Type { get; set; }
            public string? FilePath { get; set; }
    }
}
