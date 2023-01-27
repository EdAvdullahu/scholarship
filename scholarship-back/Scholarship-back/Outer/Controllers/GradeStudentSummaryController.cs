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
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<ActionResult<List<GradeStudentSummary>>> Get()
        {
            if (_context.Universities == null) return NotFound();
            return Ok(await _context.Universities.ToListAsync());
        }
        [Authorize(Roles = "SuperAdmin")]
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
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult> CreateUni(GradeStudentSummary request)
        {
            if (_context.GradeStudentSummaries == null) return NotFound();
            if (await _context.GradeStudentSummaries.AnyAsync(u => u.Id == request.Id))
            {
                return BadRequest("GradeStudent already exists.");
            }


            var gSS = new GradeStudentSummary
            {
                SubjectId = request.SubjectId,
                StudentId = request.StudentId,
                Value = request.Value
            };

            _context.GradeStudentSummaries.Add(gSS);
            await _context.SaveChangesAsync();

            return Ok("GradeStudent was created successfully");
        }

        [Authorize(Roles = "SuperAdmin")]
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
        [Authorize(Roles = "SuperAdmin")]
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
