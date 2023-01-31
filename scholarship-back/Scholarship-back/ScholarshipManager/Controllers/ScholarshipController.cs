using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Interfaces;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipManager.Dto;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.ScholarshipManager.Models.Helpers;
using Scholarship_back.ScholarshipManager.Services;
using System.Diagnostics.CodeAnalysis;

namespace Scholarship_back.ScholarshipManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScholarshipController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly BuilderService _builderService;

        public ScholarshipController(DataContext context)
        {
            _context = context;
            _builderService = new BuilderService(context);
        }
        [HttpGet]
        public async Task<ActionResult<List<Scholarship>>> Get()
        {
            return Ok(await _context.Scholarships.ToListAsync());
        }
        [AllowAnonymous]
        [HttpGet("faculty/{id}")]
        public async Task<ActionResult<List<FacultyInfo>>> GetFaculty(int id)
        {
            IFaculty infoS = new(_context);
            FacultyInfo info = infoS.FacultyToInfo(id);
            return Ok(info);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ScholarshipType>>> GetTypes()
        {
            return Ok(await _context.ScholarshipTypes.ToListAsync());
        }
        [HttpGet("criteria")]
        public async Task<ActionResult<List<ScholarshipType>>> GetCriteria()
        {
            return Ok(await _context.Criterion.ToListAsync());
        }
        [HttpGet("criteria/{id}")]
        public async Task<ActionResult<List<CriterionScholarship>>> GetCriteria(int id)
        {
            return Ok(await _context.ScholarshipCriterias.Where(x=>x.ScholarshipId==id).Include(x=>x.Criterion).ToListAsync());
        }
        [HttpGet("category/{id}")]
        public async Task<ActionResult<List<CategoryScholarship>>> GetCategory(int id)
        {
            return Ok(await _context.ScholarshipCategories.Where(x => x.ScholarshipId == id).Include(x => x.Category).ToListAsync());
        }
        [AllowAnonymous]
        [HttpPost("scholarship")]
        public async Task<ActionResult<ScholarshipReturnDto>> CreateScholarship(ScholarshipSimpleDto request)
        {
            ScholarshipReturnDto scholarship = _builderService.buildHighSchoolScholarship(request);
            if (scholarship == null)
            {
                return NotFound("something went bad");
            }
            return Ok(scholarship);

        }
        [AllowAnonymous]
        [HttpPost("type")]
        public async Task<ActionResult<ScholarshipType>> CreateType(ScholarshipTypeDto request)
        {
            ScholarshipType temp = new()
            {
                Descriptin = request.Descriptin,
                Name = request.Name
            };
            _context.ScholarshipTypes.Add(temp);
            await _context.SaveChangesAsync();
            return Ok(temp);
        }
        [AllowAnonymous]
        [HttpPost("category")]
        public async Task<ActionResult<Category>> CreateCategory(CategoryDto request)
        {
            Category temp = new()
            {
                Description = request.Description,
                Name = request.Name
            };
            _context.Categories.Add(temp);
            await _context.SaveChangesAsync();
            return Ok(temp);
        }
        [AllowAnonymous]
        [HttpPost("criterion")]
        public async Task<ActionResult<Criterion>> CreateCriterion(Criterion request)
        {
            if (request == null) return NotFound();
            Criterion temp = new()
            {
                Description = request.Description,
                Name = request.Name,
                requiresDocument = request.requiresDocument
            };
            if (temp == null) return NotFound();
            _context.Criterion.Add(temp);
            await _context.SaveChangesAsync();
            return Ok(temp);
        }
    }
}
