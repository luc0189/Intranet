using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class incapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incapacity_Employees_EmployeeId",
                table: "Incapacity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incapacity",
                table: "Incapacity");

            migrationBuilder.RenameTable(
                name: "Incapacity",
                newName: "Incapacities");

            migrationBuilder.RenameIndex(
                name: "IX_Incapacity_EmployeeId",
                table: "Incapacities",
                newName: "IX_Incapacities_EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "CantDay",
                table: "Incapacities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModify",
                table: "Incapacities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistro",
                table: "Incapacities",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserModify",
                table: "Incapacities",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRegistra",
                table: "Incapacities",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incapacities",
                table: "Incapacities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incapacities_Employees_EmployeeId",
                table: "Incapacities",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incapacities_Employees_EmployeeId",
                table: "Incapacities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incapacities",
                table: "Incapacities");

            migrationBuilder.DropColumn(
                name: "CantDay",
                table: "Incapacities");

            migrationBuilder.DropColumn(
                name: "DateModify",
                table: "Incapacities");

            migrationBuilder.DropColumn(
                name: "DateRegistro",
                table: "Incapacities");

            migrationBuilder.DropColumn(
                name: "UserModify",
                table: "Incapacities");

            migrationBuilder.DropColumn(
                name: "UserRegistra",
                table: "Incapacities");

            migrationBuilder.RenameTable(
                name: "Incapacities",
                newName: "Incapacity");

            migrationBuilder.RenameIndex(
                name: "IX_Incapacities_EmployeeId",
                table: "Incapacity",
                newName: "IX_Incapacity_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incapacity",
                table: "Incapacity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incapacity_Employees_EmployeeId",
                table: "Incapacity",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
