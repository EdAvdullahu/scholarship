using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Scholarship_back.Migrations
{
    public partial class ScholarshipManagementV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scholarships_FacultyInfo_FacultyId",
                table: "Scholarships");

            migrationBuilder.DropTable(
                name: "FacultyInfo");

            migrationBuilder.DropIndex(
                name: "IX_Scholarships_FacultyId",
                table: "Scholarships");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Scholarships");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Scholarships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FacultyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    FacultyTypeId = table.Column<int>(type: "int", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scholarships_FacultyId",
                table: "Scholarships",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scholarships_FacultyInfo_FacultyId",
                table: "Scholarships",
                column: "FacultyId",
                principalTable: "FacultyInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
