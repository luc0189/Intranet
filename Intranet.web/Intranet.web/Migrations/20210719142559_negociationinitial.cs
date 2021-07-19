using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Intranet.web.Migrations
{
    public partial class negociationinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateIn",
                table: "Negociation",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModifica",
                table: "Negociation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserModify",
                table: "Negociation",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPaga",
                table: "Negociation",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserVerifica",
                table: "Negociation",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModifica",
                table: "Negociation");

            migrationBuilder.DropColumn(
                name: "UserModify",
                table: "Negociation");

            migrationBuilder.DropColumn(
                name: "UserPaga",
                table: "Negociation");

            migrationBuilder.DropColumn(
                name: "UserVerifica",
                table: "Negociation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIn",
                table: "Negociation",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
