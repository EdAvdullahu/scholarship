namespace Scholarship_back.ScholarshipEvaluation.Dto
{
    public class EvaluationDto
    {
        public int ApplicationFormId { get; set; }
        public double TotalEvaluation { get; set; }
        public List<KeyValuePair<string, double>> Evaluation { get; set; }
    }
}
