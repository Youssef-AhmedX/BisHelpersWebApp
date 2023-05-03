using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisHelpersWebApp.Migrations
{
    public partial class addstudentlibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignmentSupport",
                columns: table => new
                {
                    AssignmentSupportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestStat = table.Column<int>(type: "int", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentSupport", x => x.AssignmentSupportId);
                });

            migrationBuilder.CreateTable(
                name: "SQsupport",
                columns: table => new
                {
                    SQsupportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestStat = table.Column<int>(type: "int", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SQsupport", x => x.SQsupportId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentSupport");

            migrationBuilder.DropTable(
                name: "SQsupport");
        }
    }
}
