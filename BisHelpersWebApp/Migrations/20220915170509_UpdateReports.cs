using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisHelpersWebApp.Migrations
{
    public partial class UpdateReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportPdfFile",
                table: "Reports");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "CurrentTotalGpa",
                table: "Reports",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "HoursDone",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThreeHoursSubjectsNum",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TwoHoursSubjectsNum",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTotalGpa",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "HoursDone",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ThreeHoursSubjectsNum",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "TwoHoursSubjectsNum",
                table: "Reports");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Reports",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "ReportPdfFile",
                table: "Reports",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
