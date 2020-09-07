using Microsoft.EntityFrameworkCore.Migrations;

namespace EdenClinic.Server.Migrations
{
    public partial class Person_Password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                schema: "dbo",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPassword",
                schema: "dbo",
                table: "Person");
        }
    }
}
