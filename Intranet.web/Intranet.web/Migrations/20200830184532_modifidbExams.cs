using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Intranet.web.Migrations
{
    public partial class modifidbExams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateModify",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistro",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserModify",
                table: "Exams",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRegistra",
                table: "Exams",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModify",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "DateRegistro",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "UserModify",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "UserRegistra",
                table: "Exams");
        }
    }
}
