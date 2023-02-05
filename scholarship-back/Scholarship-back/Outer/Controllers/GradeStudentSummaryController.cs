using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Models;
using System.Data;

namespace Scholarship_back.Outer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeStudentSummaryController : Controller
    {
        private readonly DataContext _context;

        public GradeStudentSummaryController(DataContext context)
        {
            _context = context;
        }
        /*[Authorize(Roles = "Superadmin")]*/
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<GradeStudentSummary>>> Get()
        {
            return Ok(_context.GradeStudentSummaries.ToList());
        }
        [Authorize(Roles = "Superadmin")]
        [HttpGet("GradeStudent/{Id}")]
        public async Task<ActionResult<List<Faculty>>> GetById(int Id)
        {
            if (_context.GradeStudentSummaries == null) return NotFound();
            var gradeStudent = await _context.GradeStudentSummaries.Where(x => x.Id == Id).ToListAsync();
            if (gradeStudent == null)
            {
                return NotFound();
            }
            return Ok(gradeStudent);
        }
        [Authorize(Roles = "Superadmin")]
        [HttpPost]
        public async Task<ActionResult> setGrade(GradeStudentSummaryDto request)
        {
            var gSS = new GradeStudentSummary
            {
                SubjectId = request.SubjectId,
                StudentId = request.StudentId,
                Value = request.Value
            };

            _context.GradeStudentSummaries.Add(gSS);
            await _context.SaveChangesAsync();

            return Ok("Grade was added");
        }

        [Authorize(Roles = "Superadmin")]
        [HttpPut]
        public async Task<ActionResult<List<GradeStudentSummary>>> Edit(GradeStudentSummary gradeStudent)
        {
            if (_context.GradeStudentSummaries == null) return NotFound();
            var gSS = await _context.GradeStudentSummaries.FindAsync(gradeStudent.Id);
            if (gSS == null)
            {
                return BadRequest("GradeStudent ");
            }
            gSS.SubjectId = gradeStudent.SubjectId;
            gSS.StudentId = gradeStudent.StudentId;
            gSS.Value = gradeStudent.Value;
          
            await _context.SaveChangesAsync();

            return Ok(await _context.GradeStudentSummaries.ToListAsync());
        }
        [Authorize(Roles = "Superadmin")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<List<GradeStudentSummary>>> Delete(int id)
        {
            if (_context.GradeStudentSummaries == null) return NotFound();
            var gSS = await _context.GradeStudentSummaries.FindAsync(id);
            if (gSS == null)
            {
                return BadRequest("GradeStudent is Null");
            }
            _context.GradeStudentSummaries.Remove(gSS);
            await _context.SaveChangesAsync();
            return Ok(await _context.GradeStudentSummaries.ToListAsync());
        }
    }
}
