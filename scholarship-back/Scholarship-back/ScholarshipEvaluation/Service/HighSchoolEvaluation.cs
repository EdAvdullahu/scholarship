using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipEvaluation.Dto;
using Scholarship_back.ScholarshipEvaluation.Interface;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Models;
using System;

namespace Scholarship_back.ScholarshipEvaluation.Service
{
    public class HighSchoolEvaluation
    {
        private readonly HighSchoolInterface _highSchool;
        protected ApplicationForm _application;
        protected StartEvaluationDto _startEvaluationDto;
        /*protected readonly IVerification _verify;*/
        protected readonly IEApplicationForm _applications;
        protected readonly FacultyInterface _facility;
        protected readonly IStudent _student;
        protected readonly IScholarship _scholarship;
        public HighSchoolEvaluation(/*IVerification verify, */IEApplicationForm app, FacultyInterface faculty, IStudent student, HighSchoolInterface highSchool, IScholarship scholarship)
        {
            _highSchool = highSchool;
            /*_verify = verify;*/
            _applications = app;
            _facility = faculty;
            _student = student;
            _scholarship = scholarship;
        }

        public EvaluationDto evaluateSubmision()
        {
            List<KeyValuePair<string, double>> evaluationList = new List<KeyValuePair<string, double>>();
            List<Criterion> criterias = _scholarship.getCriteriaById(_applications.getById(_application.SubmitingDeadlineId).ScholarshipId);
            criterias.ForEach((criteria) =>
            {
                if (criteria.Name.Equals("GAP"))
                {
                    double num = calculateGAP();
                    KeyValuePair<string, double> value = new KeyValuePair<string, double>(criteria.Name, num);
                    evaluationList.Add(value);
                }
                if(criteria.Name.Equals("AVG"))
                {
                    double num = calculateAVG();
                    KeyValuePair<string, double> value = new KeyValuePair<string, double>(criteria.Name, num);
                    evaluationList.Add(value);
                }
                if (criteria.Name.Equals("Interview"))
                {
                    KeyValuePair<string, double> value = new KeyValuePair<string, double>(criteria.Name, 5);
                    evaluationList.Add(value);
                }
            });
            EvaluationDto temp = new EvaluationDto
            {
                ApplicationFormId = _application.Id,
                Evaluation = evaluationList,
                TotalEvaluation = ConvertToDouble(calulateTotal(evaluationList))
            };
            return temp;
        }

        public bool verifySubmision()
        {
            /*return _verify.verifySubmition(_application);*/
            return true;
        }
        private double calculateGAP()
        {
            double gap = 0;
            int scholarshipId = _applications.getById(_application.SubmitingDeadlineId).ScholarshipId;
            Student tempStudent = _student.getStudnetById(getStudentId());
            //get priority lists for faculty and Highschool
            List<HighSchoolPriority> highSPriority= _highSchool.getPriority(tempStudent.HighSchoolId);
            List<FacultyPriority> facultyPririty = _facility.getPriorityList(_scholarship.getScholarshipById(scholarshipId).FacultyId);
            // get student grades
            List<GradeStudentSummary> gradeStudentSummaries = _highSchool.getStudentGrades(tempStudent.Id);
            int numberOfSubject = highSPriority.Count;
            highSPriority.ForEach((priority) =>
            {
                double temp = 0;
                int subjectId = priority.SubjectId;
                int fSubPriority = facultyPririty.Where(x => x.SubjectId == subjectId).Select(x=>x.value).First();
                int hsSubPriority = priority.value;
                int grade = gradeStudentSummaries.Where(x => x.SubjectId == subjectId).Select(x => x.Value).First();

                temp = (((fSubPriority + hsSubPriority) / 2D) / (5D * numberOfSubject)) * grade;
                gap = gap + temp;
            });
            return ConvertToDouble(gap);
        }
        private double calculateAVG()
        {
            double avg = 0;
            int sum = 0;
            Student tempStudent = _student.getStudnetById(getStudentId());
            List<GradeStudentSummary> gradeStudentSummaries = _highSchool.getStudentGrades(tempStudent.Id);
            gradeStudentSummaries.ForEach((grade) =>
            {
                sum += grade.Value;
            });
            avg = sum / gradeStudentSummaries.Count();
            return avg;
        }
        private double calulateTotal(List<KeyValuePair<string,double>> list)
        {
            double totalGap = 0;
            int length = _startEvaluationDto.Priority.Count();
            _startEvaluationDto.Priority.ForEach((priority) =>
            {
                double priorityValue = priority.Value;
                double value = list.Where(x => x.Key.Equals(priority.CrieteiaName)).Select(x => x.Value).FirstOrDefault();
                double temp = (priorityValue/(5*length))*value;
                totalGap += temp;
            });
            return totalGap;
        }
        private int getStudentId()
        {
            if (_application.StudentId != null)
            {
                return _application.StudentId.Value;
            }
            return 0;
        }
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
        private double ConvertToDouble(double value)
        {
            decimal decValue = (decimal)value;
            decValue = Decimal.Round(decValue, 2);
            return (double)decValue;
        }
    }
}
