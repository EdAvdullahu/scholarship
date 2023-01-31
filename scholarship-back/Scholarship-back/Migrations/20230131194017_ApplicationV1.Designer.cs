﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scholarship_back.Data;

#nullable disable

namespace Scholarship_back.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230131194017_ApplicationV1")]
    partial class ApplicationV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Scholarship_back.Outer.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FacultyDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacultyTypeId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.FacultyPriority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FacultyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacultyTypeId");

                    b.HasIndex("SubjectId");

                    b.ToTable("FacultyPriorities");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.FacultyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacultyTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FacultyTypes");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.GradeStudentSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("GradeStudentSummaries");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.HighSchool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("HighSchoolDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HighSchoolName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HighSchoolTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HighSchoolTypeId");

                    b.ToTable("HighSchools");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.HighSchoolPriority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HighSchoolTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HighSchoolTypeId");

                    b.HasIndex("SubjectId");

                    b.ToTable("HighSchoolPriorities");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.HighSchoolType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HighSchoolTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HighSchoolsTypes");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniversityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Bday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipApplication.Models.ApplicationForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApplicationStatus")
                        .HasColumnType("int");

                    b.Property<int>("DocumentListId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubmitingDeadlineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmittingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DocumentListId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubmitingDeadlineId");

                    b.ToTable("ApplicationForms");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipApplication.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("documentListId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("documentListId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipApplication.Models.DocumentList", b =>
                {
                    b.Property<int>("documentListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("documentListId"), 1L, 1);

                    b.HasKey("documentListId");

                    b.ToTable("DocumentLists");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipApplication.Models.SubmitingDeadline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ScholarshipId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ScholarshipId");

                    b.ToTable("SubmitingDeadlines");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipManager.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipManager.Models.Criterion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("requiresDocument")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Criterion");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipManager.Models.Helpers.CategoryScholarship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ScholarshipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ScholarshipId");

                    b.ToTable("ScholarshipCategories");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipManager.Models.Helpers.CriterionScholarship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CriterionId")
                        .HasColumnType("int");

                    b.Property<int>("ScholarshipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CriterionId");

                    b.HasIndex("ScholarshipId");

                    b.ToTable("ScholarshipCriterias");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipManager.Models.Scholarship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<int>("ScholarshipTypeId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("ScholarshipTypeId");

                    b.ToTable("Scholarships");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipManager.Models.ScholarshipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descriptin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ScholarshipTypes");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.Admin", b =>
                {
                    b.HasBaseType("Scholarship_back.Outer.Models.User");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasIndex("UniversityId");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.Student", b =>
                {
                    b.HasBaseType("Scholarship_back.Outer.Models.User");

                    b.Property<int>("HighSchoolId")
                        .HasColumnType("int");

                    b.HasIndex("HighSchoolId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.Faculty", b =>
                {
                    b.HasOne("Scholarship_back.Outer.Models.FacultyType", "FacultyType")
                        .WithMany()
                        .HasForeignKey("FacultyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholarship_back.Outer.Models.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacultyType");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.FacultyPriority", b =>
                {
                    b.HasOne("Scholarship_back.Outer.Models.FacultyType", "FacultyType")
                        .WithMany()
                        .HasForeignKey("FacultyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholarship_back.Outer.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacultyType");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.GradeStudentSummary", b =>
                {
                    b.HasOne("Scholarship_back.Outer.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholarship_back.Outer.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.HighSchool", b =>
                {
                    b.HasOne("Scholarship_back.Outer.Models.HighSchoolType", "HighSchoolType")
                        .WithMany()
                        .HasForeignKey("HighSchoolTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HighSchoolType");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.HighSchoolPriority", b =>
                {
                    b.HasOne("Scholarship_back.Outer.Models.HighSchoolType", "HighSchoolType")
                        .WithMany()
                        .HasForeignKey("HighSchoolTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholarship_back.Outer.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HighSchoolType");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipApplication.Models.ApplicationForm", b =>
                {
                    b.HasOne("Scholarship_back.ScholarshipApplication.Models.DocumentList", "DocumentList")
                        .WithMany()
                        .HasForeignKey("DocumentListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholarship_back.Outer.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("Scholarship_back.ScholarshipApplication.Models.SubmitingDeadline", "SubmittingDeadline")
                        .WithMany()
                        .HasForeignKey("SubmitingDeadlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentList");

                    b.Navigation("Student");

                    b.Navigation("SubmittingDeadline");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipApplication.Models.Document", b =>
                {
                    b.HasOne("Scholarship_back.ScholarshipApplication.Models.DocumentList", null)
                        .WithMany("Documents")
                        .HasForeignKey("documentListId");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipApplication.Models.SubmitingDeadline", b =>
                {
                    b.HasOne("Scholarship_back.ScholarshipManager.Models.Scholarship", "Scholarship")
                        .WithMany()
                        .HasForeignKey("ScholarshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scholarship");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipManager.Models.Helpers.CategoryScholarship", b =>
                {
                    b.HasOne("Scholarship_back.ScholarshipManager.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholarship_back.ScholarshipManager.Models.Scholarship", "Scholarship")
                        .WithMany()
                        .HasForeignKey("ScholarshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Scholarship");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipManager.Models.Helpers.CriterionScholarship", b =>
                {
                    b.HasOne("Scholarship_back.ScholarshipManager.Models.Criterion", "Criterion")
                        .WithMany()
                        .HasForeignKey("CriterionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholarship_back.ScholarshipManager.Models.Scholarship", "Scholarship")
                        .WithMany()
                        .HasForeignKey("ScholarshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Criterion");

                    b.Navigation("Scholarship");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipManager.Models.Scholarship", b =>
                {
                    b.HasOne("Scholarship_back.Outer.Models.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scholarship_back.ScholarshipManager.Models.ScholarshipType", "ScholarshipType")
                        .WithMany()
                        .HasForeignKey("ScholarshipTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("ScholarshipType");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.Admin", b =>
                {
                    b.HasOne("Scholarship_back.Outer.Models.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("Scholarship_back.Outer.Models.Student", b =>
                {
                    b.HasOne("Scholarship_back.Outer.Models.HighSchool", "HighSchool")
                        .WithMany()
                        .HasForeignKey("HighSchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HighSchool");
                });

            modelBuilder.Entity("Scholarship_back.ScholarshipApplication.Models.DocumentList", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
