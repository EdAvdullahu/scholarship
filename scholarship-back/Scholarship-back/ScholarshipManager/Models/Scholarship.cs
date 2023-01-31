using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipManager.Interfaces;
using Scholarship_back.ScholarshipManager.Models.Helpers;

namespace Scholarship_back.ScholarshipManager.Models
{
    public class Scholarship
    {
        public int Id { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
        public ScholarshipType? ScholarshipType { get; set; }
        public int ScholarshipTypeId { get; set; }
        public Faculty? Faculty { get; set; }
        public int FacultyId { get; set; }
    }
}
