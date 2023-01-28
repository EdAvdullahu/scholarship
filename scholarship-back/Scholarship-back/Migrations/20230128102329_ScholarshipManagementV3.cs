using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scholarship_back.Migrations
{
    public partial class ScholarshipManagementV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scholarships_FacultyInfo_Facultyid",
                table: "Scholarships");

            migrationBuilder.RenameColumn(
                name: "Facultyid",
                table: "Scholarships",
                newName: "FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Scholarships_Facultyid",
                table: "Scholarships",
                newName: "IX_Scholarships_FacultyId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FacultyInfo",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarships_FacultyInfo_FacultyId",
                table: "Scholarships",
                column: "FacultyId",
                principalTable: "FacultyInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scholarships_FacultyInfo_FacultyId",
                table: "Scholarships");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Scholarships",
                newName: "Facultyid");

            migrationBuilder.RenameIndex(
                name: "IX_Scholarships_FacultyId",
                table: "Scholarships",
                newName: "IX_Scholarships_Facultyid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FacultyInfo",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarships_FacultyInfo_Facultyid",
                table: "Scholarships",
                column: "Facultyid",
                principalTable: "FacultyInfo",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
