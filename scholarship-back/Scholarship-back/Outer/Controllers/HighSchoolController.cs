using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Models;

namespace Scholarship_back.Outer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighSchoolController : Controller
    {
        private readonly DataContext _context;

        public HighSchoolController(DataContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Superadmin")]
        [HttpGet]
        public async Task<ActionResult<List<HighSchool>>> Get()
        {
            if (_context.HighSchools == null)
            {
                return NotFound();
            }
            return Ok(await _context.HighSchools.ToListAsync());
        }

        [Authorize(Roles = "Superadmin")]
        [HttpGet("highschool/{Id}")]
        public async Task<ActionResult<List<Faculty>>> GetByHS(int Id)
        {
            if (_context.HighSchoolsTypes == null) return NotFound();
            var highSchools = await _context.HighSchoolsTypes.Where(x => x.Id == Id).ToListAsync();
            if (highSchools == null)
            {
                return NotFound();
            }
            return Ok(highSchools);
        }
        [Authorize(Roles = "Superadmin,Admin")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<University>> Get(int Id)
        {
            if (_context.HighSchools == null) return NotFound();
            var uni = await _context.HighSchools.FindAsync(Id);
            if (uni == null)
            {
                return NotFound("Highschool not found");
            }
            return Ok(uni);
        }

        [Authorize(Roles = "Superadmin")]
        [HttpPost]
        public async Task<ActionResult> CreateUni(HighSchoolDto request)
        {
            if (_context.HighSchools == null) return NotFound();
            if (await _context.HighSchools.AnyAsync(u => u.HighSchoolName == request.HighSchoolName))
            {
                return BadRequest("Highschool already exists.");
            }


            var hS = new HighSchool
            {
                HighSchoolName = request.HighSchoolName,
                HighSchoolDescription = request.HighSchoolDescription,
                HighSchoolTypeId = request.HighSchoolTypeId
            };

            _context.HighSchools.Add(hS);
            await _context.SaveChangesAsync();

            return Ok("HighSchool was created successfully");
        }
        [Authorize(Roles = "Superadmin")]
        [HttpPost("HighSchoolType")]
        public async Task<ActionResult> CreateFaculty(HighSchoolTypeDto request)
        {
            if (_context.HighSchoolsTypes == null) return NotFound();
            var hST = new HighSchoolType
            {
                HighSchoolTypeName = request.HighSchoolTypeName,
                Description = request.Description
            };

            _context.HighSchoolsTypes.Add(hST);
            await _context.SaveChangesAsync();

            return Ok("HighSchoolType was created successfully");
        }
    }
}
