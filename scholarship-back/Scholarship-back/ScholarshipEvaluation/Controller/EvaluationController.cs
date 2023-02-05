using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Interface;
using Scholarship_back.ScholarshipEvaluation.Dto;
using Scholarship_back.ScholarshipEvaluation.Service;
using Scholarship_back.ScholarshipManager.Interfaces;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Scholarship_back.ScholarshipEvaluation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly HighSchoolEvaluation _eval;
        public EvaluationController(IEApplicationForm app, FacultyInterface faculty, IStudent student, HighSchoolInterface highSchool, IScholarship scholarship)
        {
            _eval = new HighSchoolEvaluation(app,faculty,student,highSchool,scholarship);
        }
        /*[Authorize(Roles = "Superadmin")]*/
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<List<EvaluationDto>>> Get(StartEvaluationDto request)
        {
            Evaluator _evaluatior = new Evaluator(_eval);
            return _evaluatior.startEvaluation(request);
        }
    }
}
