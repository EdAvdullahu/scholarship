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
    public class FacultyController : ControllerBase
    {
        private readonly DataContext _context;
        public FacultyController(DataContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<ActionResult<List<FacultyType>>> Get()
        {
            return Ok(_context.FacultyTypes.ToList());
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<ActionResult> CreateFacultyType(FacultyTypeDto request)
        {
            if (_context.FacultyTypes.Any(u => u.FacultyTypeName == request.FacultyTypeName))
            {
                return BadRequest("Faculty type already exists.");
            }

            var facultyType = new FacultyType
            {
                FacultyTypeName = request.FacultyTypeName,
                Description = request.Description
            };

            _context.FacultyTypes.Add(facultyType);
            await _context.SaveChangesAsync();

            return Ok("Faculty type was created successfully");
        }
    }
}
