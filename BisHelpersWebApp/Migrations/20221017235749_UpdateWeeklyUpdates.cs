using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisHelpersWebApp.Migrations
{
    public partial class UpdateWeeklyUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "WeeklyUpdates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "WeeklyUpdates");
        }
    }
}
