using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisHelpersWebApp.Migrations
{
    public partial class SeedRoles : Migration
    {


        private string UserRoleId = Guid.NewGuid().ToString();
        private string AdminRoleId = Guid.NewGuid().ToString();


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);
            //SeedUser(migrationBuilder);
            //SeedUserRoles(migrationBuilder);



            //migrationBuilder.AlterColumn<int>(
            //    name: "StudentCollageId",
            //    table: "AspNetUsers",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");
        }
        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo]. [AspNetRoles] ([id],[Name], [NormalizedName], [ConcurrencyStamp])
            VALUES ('{AdminRoleId}' , 'Administrator' , 'ADMINISTRATOR' , null);");
            migrationBuilder.Sql(@$"INSERT INTO [dbo]. [AspNetRoles] ([id], [Name], [NormalizedName],[ConcurrencyStamp])
            VALUES ('{UserRoleId}', 'User' , 'USER' , null);");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentCollageId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
