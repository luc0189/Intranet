using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Intranet.web.Migrations
{
    public partial class modifyDbSons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Datebirth",
                table: "Sons",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModify",
                table: "Sons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistro",
                table: "Sons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserModify",
                table: "Sons",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRegistra",
                table: "Sons",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModify",
                table: "Sons");

            migrationBuilder.DropColumn(
                name: "DateRegistro",
                table: "Sons");

            migrationBuilder.DropColumn(
                name: "UserModify",
                table: "Sons");

            migrationBuilder.DropColumn(
                name: "UserRegistra",
                table: "Sons");

            migrationBuilder.AlterColumn<string>(
                name: "Datebirth",
                table: "Sons",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
