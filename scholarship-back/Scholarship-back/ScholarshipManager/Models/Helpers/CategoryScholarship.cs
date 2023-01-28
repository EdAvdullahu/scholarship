namespace Scholarship_back.ScholarshipManager.Models.Helpers
{
    public class CategoryScholarship
    {
        public int Id { get; set; }
        public Scholarship? Scholarship { get; set; }
        public int ScholarshipId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
