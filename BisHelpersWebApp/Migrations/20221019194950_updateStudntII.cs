using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisHelpersWebApp.Migrations
{
    public partial class updateStudntII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeeklyPaymentStat",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeeklyPaymentStat",
                table: "AspNetUsers");
        }
    }
}
