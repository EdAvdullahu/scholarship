using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipEvaluation.Dto;

namespace Scholarship_back.ScholarshipEvaluation.Service
{
    public class Evaluator
    {
        private readonly HighSchoolEvaluation _evaluation;
        public Evaluator(HighSchoolEvaluation evaluation)
        {
            _evaluation = evaluation;
        }
        public List<EvaluationDto> startEvaluation(StartEvaluationDto evaluation)
        {
            List<EvaluationDto> evaluations = new List<EvaluationDto>();
            List<ApplicationForm> applicatins = _evaluation.getApplications(evaluation.DeadlineId);
            _evaluation.setStartEvaluator(evaluation);
            applicatins.ForEach((application) =>
            {
                _evaluation.setApplication(application);
                EvaluationDto temp = _evaluation.evaluateSubmision();
                evaluations.Add(temp);
            });
            return evaluations;
        }
    }
}
