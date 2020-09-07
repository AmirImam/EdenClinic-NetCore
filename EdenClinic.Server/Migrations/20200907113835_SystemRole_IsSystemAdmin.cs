using Microsoft.EntityFrameworkCore.Migrations;

namespace EdenClinic.Server.Migrations
{
    public partial class SystemRole_IsSystemAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSystemAdmin",
                schema: "dbo",
                table: "SystemRole",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSystemAdmin",
                schema: "dbo",
                table: "SystemRole");
        }
    }
}
