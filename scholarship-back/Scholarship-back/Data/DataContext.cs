using Microsoft.EntityFrameworkCore;
using Scholarship_back.Outer.Models;

namespace Scholarship_back.Data
{
    public class DataContext: DbContext  
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<University>? Universities { get; set; }
        public DbSet<Faculty>? Faculties { get; set; }
        public DbSet<FacultyType>? FacultyTypes { get; set; }
        public DbSet<HighSchool>? HighSchools { get; set; }
        public DbSet<HighSchoolType>? HighSchoolsTypes { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<GradeStudentSummary>? GradeStudentSummaries { get; set; } 
        public DbSet<FacultyPriority>? FacultyPriorities { get; set; }
        public DbSet<HighSchoolPriority>? HighSchoolPriorities { get; set; }

    }
}
