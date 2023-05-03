using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisHelpersWebApp.Migrations
{
    public partial class AddStudentIdToSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "SQsupport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "AssignmentSupport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "SQsupport");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AssignmentSupport");
        }
    }
}
