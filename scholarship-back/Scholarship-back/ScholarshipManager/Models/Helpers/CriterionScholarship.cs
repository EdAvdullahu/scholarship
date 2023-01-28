namespace Scholarship_back.ScholarshipManager.Models.Helpers
{
    public class CriterionScholarship
    {
        public int Id { get; set; }
        public Scholarship? Scholarship { get; set; }
        public int ScholarshipId { get; set; }
        public Criterion Criterion { get; set; }
        public int CriterionId { get; set; }
    }
}
