namespace Scholarship_back.ScholarshipEvaluation.Dto
{
    public class StartEvaluationDto
    {
        public int DeadlineId { get; set; }
        public List<CriteriaPriority> Priority { get; set; }
        public List<ManualGrade>? grades { get; set; }
    }
}
