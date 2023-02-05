using Org.BouncyCastle.Asn1.X509;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipEvaluation.Dto;
using Scholarship_back.ScholarshipEvaluation.Interface;
using Scholarship_back.ScholarshipManager.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Scholarship_back.ScholarshipEvaluation.Service
{
    public abstract class Evaluation
    {
        protected ApplicationForm _application;
        protected StartEvaluationDto _startEvaluationDto;
        /*protected readonly IVerification _verify;*/
        protected readonly IEApplicationForm _applications;
        protected readonly FacultyInterface _facility;
        protected readonly IStudent _student;
        protected readonly IScholarship _scholarship;
        public Evaluation(/*IVerification verify, */IEApplicationForm applicationForm, FacultyInterface facultyInterface, IStudent student, IScholarship scholarship)
        {
            /*_verify = verify;*/
            _applications = applicationForm;
            _facility = facultyInterface;
            _student = student;
            _scholarship = scholarship;
        }

        public abstract bool verifySubmision();
        public abstract EvaluationDto evaluateSubmision();

        public void setApplication(ApplicationForm app)
        {
            _application = app;
        }
        public List<ApplicationForm> getApplications(int id)
        {
            return _applications.getApplicationsByDeadlineId(id);
        }
        public void setStartEvaluator(StartEvaluationDto start)
        {
            _startEvaluationDto = start;
        }
    }
}
