using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class SubjectController : ControllerBase
    {
        private readonly DataContext _context;
        public SubjectController(DataContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<ActionResult<List<Subject>>> Get()
        {
            return Ok(await _context.Subjects.ToListAsync());
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult> createSubject(SubjectDto request)
        {
            if (_context.Subjects.Any(u => u.Name == request.Name))
            {
                return BadRequest("Subject already exists.");
            }


            var sub = new Subject
            {
                Name = request.Name
            };

            _context.Subjects.Add(sub);
            await _context.SaveChangesAsync();

            return Ok("Subject was created successfully");
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("highschoolpriority")]
        public async Task<ActionResult> addPriority(HighSchoolPriorityDto request)
        {
            if (_context.HighSchoolPriorities.Any(u => u.HighSchoolTypeId == request.HighSchoolTypeId && u.SubjectId==request.SubjectId))
            {
                return BadRequest("Priority already exists.");
            }


            var priority = new HighSchoolPriority
            {
                SubjectId = request.SubjectId,
                HighSchoolTypeId = request.HighSchoolTypeId,
                value = request.value
            };

            _context.HighSchoolPriorities.Add(priority);
            await _context.SaveChangesAsync();

            return Ok("Priority was created successfully");
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("facultyprioritypriority")]
        public async Task<ActionResult> addPriority(FacultyPriorityDto request)
        {
            if (_context.FacultyPriorities.Any(u => u.FacultyTypeId == request.FacultyTypeId && u.SubjectId == request.SubjectId))
            {
                return BadRequest("Priority already exists.");
            }


            var priority = new FacultyPriority
            {
                SubjectId = request.SubjectId,
                FacultyTypeId = request.FacultyTypeId,
                value = request.value
            };

            _context.FacultyPriorities.Add(priority);
            await _context.SaveChangesAsync();

            return Ok("Priority was created successfully");
        }
    }
}
