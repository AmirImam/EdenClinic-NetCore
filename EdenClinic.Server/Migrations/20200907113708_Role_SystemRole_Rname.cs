using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EdenClinic.Server.Migrations
{
    public partial class Role_SystemRole_Rname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Role_RoleID",
                schema: "dbo",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePage_Role_RoleID",
                schema: "dbo",
                table: "RolePage");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "SystemRole",
                schema: "dbo",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(nullable: false),
                    RoleName = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRole", x => x.RoleID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Person_SystemRole_RoleID",
                schema: "dbo",
                table: "Person",
                column: "RoleID",
                principalSchema: "dbo",
                principalTable: "SystemRole",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePage_SystemRole_RoleID",
                schema: "dbo",
                table: "RolePage",
                column: "RoleID",
                principalSchema: "dbo",
                principalTable: "SystemRole",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_SystemRole_RoleID",
                schema: "dbo",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePage_SystemRole_RoleID",
                schema: "dbo",
                table: "RolePage");

            migrationBuilder.DropTable(
                name: "SystemRole",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Role_RoleID",
                schema: "dbo",
                table: "Person",
                column: "RoleID",
                principalSchema: "dbo",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePage_Role_RoleID",
                schema: "dbo",
                table: "RolePage",
                column: "RoleID",
                principalSchema: "dbo",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
