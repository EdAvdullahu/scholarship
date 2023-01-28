using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly DataContext _context;
        public UniversityController(DataContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Superadmin")]
        [HttpGet]
        public async Task<ActionResult<List<University>>> Get()
        {
            if (_context.Universities == null) return NotFound();
            return Ok(await _context.Universities.ToListAsync());
        }
        [Authorize(Roles = "Superadmin")]
        [HttpGet("faculty/{Id}")]
        public async Task<ActionResult<List<Faculty>>> GetByUni(int Id)
        {
            if (_context.Faculties == null) return NotFound();
            var faculties = await _context.Faculties.Where(x => x.UniversityId == Id).ToListAsync();
            if(faculties == null)
            {
                return NotFound();
            }
            return Ok(faculties);
        }
        [Authorize(Roles = "Superadmin,Admin")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<University>> Get(int Id)
        {
            if (_context.Universities == null) return NotFound();
            var uni = await _context.Universities.FindAsync(Id);
            if (uni == null)
            {
                return NotFound("University not found");
            }
            return Ok(uni);
        }
        [Authorize(Roles = "Superadmin")]
        [HttpPost]
        public async Task<ActionResult> CreateUni(UniversityDto request)
        {
            if (_context.Universities == null) return NotFound();
            if (await _context.Universities.AnyAsync(u => u.UniversityName == request.UniversityName))
            {
                return BadRequest("University already exists.");
            }


            var uni = new University
            {
                UniversityName = request.UniversityName,
                Description = request.Description
            };

            _context.Universities.Add(uni);
            await _context.SaveChangesAsync();

            return Ok("University was created successfully");
        }
        [Authorize(Roles = "Superadmin")]
        [HttpPost("faculty")]
        public async Task<ActionResult> CreateFaculty(FacultyDto request)
        {
            if (_context.Faculties == null) return NotFound();
            var faculty = new Faculty
            {
                FacultyName = request.FacultyName,
                FacultyDescription = request.FacultyDescription,
                FacultyTypeId = request.FacultyTypeId,
                UniversityId = request.UniversityId
            };

            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();

            return Ok("Faculty was created successfully");
        }
    }
}
