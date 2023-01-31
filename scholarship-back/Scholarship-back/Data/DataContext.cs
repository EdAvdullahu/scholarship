using Microsoft.EntityFrameworkCore;
using Scholarship_back.Outer.Dto;
using Scholarship_back.Outer.Models;
using Scholarship_back.ScholarshipApplication.Models;
using Scholarship_back.ScholarshipManager.Models;
using Scholarship_back.ScholarshipManager.Models.Helpers;

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


        // Scholarship
        public DbSet<Scholarship>? Scholarships { get; set; }
        public DbSet<ScholarshipType>? ScholarshipTypes { get; set; }
        public DbSet<Criterion>? Criterion { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<CategoryScholarship>? ScholarshipCategories { get; set; }
        public DbSet<CriterionScholarship>? ScholarshipCriterias { get; set; }

        //Application
        public DbSet<ApplicationForm>? ApplicationForms { get; set; }
        public DbSet<Status>? Statuses { get; set; }
        public DbSet<Document>? Documents { get; set; }
        public DbSet<DocumentList>? DocumentLists { get; set; }
        public DbSet<DocumentType>? DocumentTypes { get; set; }
        public DbSet<SubmitingDeadline>? SubmitingDeadlines { get; set; }    
    }
}
