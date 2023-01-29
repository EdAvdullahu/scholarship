using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Models;
using Scholarship_back.Services;
using System;
using System.ComponentModel.Design;

namespace Scholarship_back.Outer.Interfaces
{
    public class IFaculty
    {
        private readonly DataContext _context;
        public IFaculty(DataContext context)
        {
            _context = context;
        }
        public FacultyInfo? FacultyToInfo(int Id)
        {
            Faculty faculty = _context.Faculties.Where(x => x.Id == Id).FirstOrDefault();
            if (faculty == null)
            {
                return null;
            }
            FacultyInfo info = new()
            {
                FacultyId = faculty.Id,
                UniversityId = faculty.UniversityId,
                FacultyTypeId = faculty.FacultyTypeId,
            };
            return info;
        }
    }
}
