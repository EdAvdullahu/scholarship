using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scholarship_back.Migrations
{
    public partial class ApplicationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacultyTypeId",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Scholarships");

            migrationBuilder.AddColumn<bool>(
                name: "requiresDocument",
                table: "Criterion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DocumentLists",
                columns: table => new
                {
                    documentListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLists", x => x.documentListId);
                });

            migrationBuilder.CreateTable(
                name: "SubmitingDeadlines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScholarshipId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmitingDeadlines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubmitingDeadlines_Scholarships_ScholarshipId",
                        column: x => x.ScholarshipId,
                        principalTable: "Scholarships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    documentListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentLists_documentListId",
                        column: x => x.documentListId,
                        principalTable: "DocumentLists",
                        principalColumn: "documentListId");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentListId = table.Column<int>(type: "int", nullable: false),
                    ApplicationStatus = table.Column<int>(type: "int", nullable: false),
                    SubmittingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    SubmitingDeadlineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationForms_DocumentLists_DocumentListId",
                        column: x => x.DocumentListId,
                        principalTable: "DocumentLists",
                        principalColumn: "documentListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationForms_SubmitingDeadlines_SubmitingDeadlineId",
                        column: x => x.SubmitingDeadlineId,
                        principalTable: "SubmitingDeadlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationForms_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scholarships_FacultyId",
                table: "Scholarships",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_DocumentListId",
                table: "ApplicationForms",
                column: "DocumentListId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_StudentId",
                table: "ApplicationForms",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_SubmitingDeadlineId",
                table: "ApplicationForms",
                column: "SubmitingDeadlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_documentListId",
                table: "Documents",
                column: "documentListId");

            migrationBuilder.CreateIndex(
                name: "IX_SubmitingDeadlines_ScholarshipId",
                table: "SubmitingDeadlines",
                column: "ScholarshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarships_Faculties_FacultyId",
                table: "Scholarships",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scholarships_Faculties_FacultyId",
                table: "Scholarships");

            migrationBuilder.DropTable(
                name: "ApplicationForms");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "SubmitingDeadlines");

            migrationBuilder.DropTable(
                name: "DocumentLists");

            migrationBuilder.DropIndex(
                name: "IX_Scholarships_FacultyId",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "requiresDocument",
                table: "Criterion");

            migrationBuilder.AddColumn<int>(
                name: "FacultyTypeId",
                table: "Scholarships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UniversityId",
                table: "Scholarships",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
